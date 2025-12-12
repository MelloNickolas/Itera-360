using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using dominio;

public class Program
{
    // Listas em memória
    static List<Item> itens = new List<Item>();
    static List<Emprestimo> emprestimos = new List<Emprestimo>();
    static List<Usuario> usuarios = new List<Usuario>();

    // Caminho dos arquivos
    static readonly string pastaArquivos = "files";
    static readonly string caminhoItensJson = Path.Combine(pastaArquivos, "itens.json");
    static readonly string caminhoEmprestimosJson = Path.Combine(pastaArquivos, "emprestimos.json");
    static readonly string caminhoUsuariosJson = Path.Combine(pastaArquivos, "usuarios.json");

    public static void Main(string[] args)
    {
        Directory.CreateDirectory(pastaArquivos);

        Console.WriteLine("Carregando dados, por favor aguarde...");

        CarregarItens();
        CarregarUsuarios();
        CarregarEmprestimos();

        int opcao = -1;

        while (opcao != 0)
        {
            Console.WriteLine("\n=========== MENU ===========");
            Console.WriteLine("1 - Cadastrar item");
            Console.WriteLine("2 - Listar itens");
            Console.WriteLine("3 - Excluir item");
            Console.WriteLine("4 - Atualizar item");

            Console.WriteLine("5 - Cadastrar usuário");
            Console.WriteLine("6 - Listar usuários");

            Console.WriteLine("7 - Registrar empréstimo");
            Console.WriteLine("8 - Listar empréstimos");
            Console.WriteLine("9 - Buscar empréstimo por ID");
            Console.WriteLine("10 - Listar empréstimos por usuário");
            Console.WriteLine("11 - Marcar devolução");

            Console.WriteLine("0 - Sair");
            Console.Write("Escolha: ");

            int.TryParse(Console.ReadLine(), out opcao);
            Console.Clear();

            switch (opcao)
            {
                case 1: CadastrarItem(); break;
                case 2: ListarItens(); break;
                case 3: ExcluirItem(); break;
                case 4: AtualizarItem(); break;

                case 5: CadastrarUsuario(); break;
                case 6: ListarUsuarios(); break;

                case 7: RegistrarEmprestimo(); break;
                case 8: ListarEmprestimos(); break;
                case 9: BuscarEmprestimoPorId(); break;
                case 10: ListarEmprestimosPorUsuario(); break;
                case 11: MarcarDevolucao(); break;

                case 0:
                    Console.WriteLine("Finalizando...");
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    // ============================
    //  CARREGAR / SALVAR JSON
    // ============================

    static void CarregarItens()
    {
        if (File.Exists(caminhoItensJson))
        {
            itens = JsonConvert.DeserializeObject<List<Item>>(File.ReadAllText(caminhoItensJson)) ?? new List<Item>();
        }
        else
        {
            itens = new List<Item>();
            SalvarItens();
        }
    }

    static void SalvarItens()
    {
        File.WriteAllText(caminhoItensJson, JsonConvert.SerializeObject(itens, Formatting.Indented));
    }

    static void CarregarUsuarios()
    {
        if (File.Exists(caminhoUsuariosJson))
        {
            usuarios = JsonConvert.DeserializeObject<List<Usuario>>(File.ReadAllText(caminhoUsuariosJson)) ?? new List<Usuario>();
        }
        else
        {
            usuarios = new List<Usuario>();
            SalvarUsuarios();
        }
    }

    static void SalvarUsuarios()
    {
        File.WriteAllText(caminhoUsuariosJson, JsonConvert.SerializeObject(usuarios, Formatting.Indented));
    }

    static void CarregarEmprestimos()
    {
        if (File.Exists(caminhoEmprestimosJson))
        {
            emprestimos = JsonConvert.DeserializeObject<List<Emprestimo>>(File.ReadAllText(caminhoEmprestimosJson)) ?? new List<Emprestimo>();
        }
        else
        {
            emprestimos = new List<Emprestimo>();
            SalvarEmprestimos();
        }
    }

    static void SalvarEmprestimos()
    {
        File.WriteAllText(caminhoEmprestimosJson, JsonConvert.SerializeObject(emprestimos, Formatting.Indented));
    }


    // ============================
    //  GERAR IDs
    // ============================

    static int ProximoIdItem() =>
        itens.Count == 0 ? 1 : itens.Max(i => i.IDItem) + 1;

    static int ProximoIdUsuario() =>
        usuarios.Count == 0 ? 1 : usuarios.Max(u => u.IDUsuario) + 1;

    static int ProximoIdEmprestimo() =>
        emprestimos.Count == 0 ? 1 : emprestimos.Max(e => e.IDEmprestimo) + 1;


    // ============================
    //  ITENS
    // ============================

    static void CadastrarItem()
    {
        Console.Write("Nome do item: ");
        string nome = Console.ReadLine();

        var item = new Item
        {
            IDItem = ProximoIdItem(),
            Nome = nome,
            Disponivel = true
        };

        itens.Add(item);
        SalvarItens();

        Console.WriteLine("✔ Item cadastrado!");
    }

    static void ListarItens()
    {
        if (!itens.Any())
        {
            Console.WriteLine("Nenhum item cadastrado.");
            return;
        }

        foreach (var i in itens)
        {
            Console.WriteLine($"{i.IDItem} - {i.Nome} - {(i.Disponivel ? "Disponível" : "Indisponível")}");
        }
    }

    static void ExcluirItem()
    {
        Console.Write("ID do item: ");
        int.TryParse(Console.ReadLine(), out int id);

        var item = itens.FirstOrDefault(i => i.IDItem == id);
        if (item == null)
        {
            Console.WriteLine("Item não encontrado.");
            return;
        }

        // Não permite excluir item com empréstimo ativo
        bool emprestado = emprestimos.Any(e => e.IDItem == id && !e.Devolvido);
        if (emprestado)
        {
            Console.WriteLine("Item não pode ser excluído: existe um empréstimo ativo.");
            return;
        }

        itens.Remove(item);
        SalvarItens();
        Console.WriteLine("✔ Item excluído!");
    }

    static void AtualizarItem()
    {
        Console.Write("ID do item: ");
        int.TryParse(Console.ReadLine(), out int id);

        var item = itens.FirstOrDefault(i => i.IDItem == id);
        if (item == null)
        {
            Console.WriteLine("Item não encontrado.");
            return;
        }

        Console.Write($"Novo nome (atual: {item.Nome}): ");
        string nome = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nome)) item.Nome = nome;

        Console.Write("Disponível? (1=Sim, 0=Não): ");
        string disp = Console.ReadLine();
        item.Disponivel = disp == "1";

        SalvarItens();
        Console.WriteLine("✔ Item atualizado!");
    }

    // ============================
    //  USUÁRIOS
    // ============================

    static void CadastrarUsuario()
    {
        Console.Write("Nome do usuário: ");
        string nome = Console.ReadLine();

        var usuario = new Usuario
        {
            IDUsuario = ProximoIdUsuario(),
            Nome = nome
        };

        usuarios.Add(usuario);
        SalvarUsuarios();

        Console.WriteLine("✔ Usuário cadastrado!");
    }

    static void ListarUsuarios()
    {
        if (!usuarios.Any())
        {
            Console.WriteLine("Nenhum usuário cadastrado.");
            return;
        }

        foreach (var u in usuarios)
        {
            Console.WriteLine($"{u.IDUsuario} - {u.Nome}");
        }
    }

    // ============================
    //  EMPRÉSTIMOS
    // ============================

    static void RegistrarEmprestimo()
    {
        Console.Write("ID do usuário: ");
        int.TryParse(Console.ReadLine(), out int usuarioId);

        if (!usuarios.Any(u => u.IDUsuario == usuarioId))
        {
            Console.WriteLine("Usuário não encontrado.");
            return;
        }

        Console.Write("ID do item: ");
        int.TryParse(Console.ReadLine(), out int itemId);

        var item = itens.FirstOrDefault(i => i.IDItem == itemId);
        if (item == null)
        {
            Console.WriteLine("Item não encontrado.");
            return;
        }

        if (!item.Disponivel)
        {
            Console.WriteLine("Item indisponível.");
            return;
        }

        Console.Write("Data prevista de devolução (dd/MM/yyyy): ");
        DateTime dataPrevista;
        if (!DateTime.TryParse(Console.ReadLine(), out dataPrevista))
        {
            dataPrevista = DateTime.Now.AddDays(7);
        }

        var emprestimo = new Emprestimo
        {
            IDEmprestimo = ProximoIdEmprestimo(),
            IDUsuario = usuarioId,
            IDItem = itemId,
            DataEmprestimo = DateTime.Now,
            DataDevolucaoPrevista = dataPrevista,
            Devolvido = false
        };

        emprestimos.Add(emprestimo);

        item.Disponivel = false;

        SalvarEmprestimos();
        SalvarItens();

        Console.WriteLine("✔ Empréstimo registrado!");
    }

    static void ListarEmprestimos()
    {
        if (!emprestimos.Any())
        {
            Console.WriteLine("Nenhum empréstimo registrado.");
            return;
        }

        foreach (var e in emprestimos)
        {
            Console.WriteLine(
                $"{e.IDEmprestimo}: Usuário {e.IDUsuario}, Item {e.IDItem}, " +
                $"Empréstimo: {e.DataEmprestimo:dd/MM/yyyy}, " +
                $"Devolvido: {(e.Devolvido ? "Sim" : "Não")}"
            );
        }
    }

    static void BuscarEmprestimoPorId()
    {
        Console.Write("ID do empréstimo: ");
        int.TryParse(Console.ReadLine(), out int id);

        var e = emprestimos.FirstOrDefault(x => x.IDEmprestimo == id);
        if (e == null)
        {
            Console.WriteLine("Empréstimo não encontrado.");
            return;
        }

        Console.WriteLine(
            $"{e.IDEmprestimo}: Usuário {e.IDUsuario}, Item {e.IDItem}, " +
            $"Emprestado em {e.DataEmprestimo:dd/MM/yyyy}, " +
            $"Previsto para {e.DataDevolucaoPrevista:dd/MM/yyyy}, " +
            $"Devolvido: {(e.Devolvido ? "Sim" : "Não")}"
        );
    }

    static void ListarEmprestimosPorUsuario()
    {
        Console.Write("ID do usuário: ");
        int.TryParse(Console.ReadLine(), out int usuarioId);

        var lista = emprestimos.Where(e => e.IDUsuario == usuarioId).ToList();

        if (!lista.Any())
        {
            Console.WriteLine("Nenhum empréstimo encontrado para este usuário.");
            return;
        }

        foreach (var e in lista)
        {
            Console.WriteLine(
                $"{e.IDEmprestimo}: Item {e.IDItem}, " +
                $"Data {e.DataEmprestimo:dd/MM/yyyy}, " +
                $"Devolvido: {(e.Devolvido ? "Sim" : "Não")}"
            );
        }
    }

    static void MarcarDevolucao()
    {
        Console.Write("ID do empréstimo: ");
        int.TryParse(Console.ReadLine(), out int id);

        var emprestimo = emprestimos.FirstOrDefault(e => e.IDEmprestimo == id);
        if (emprestimo == null)
        {
            Console.WriteLine("Empréstimo não encontrado.");
            return;
        }

        if (emprestimo.Devolvido)
        {
            Console.WriteLine("Este empréstimo já foi devolvido.");
            return;
        }

        emprestimo.Devolvido = true;
        emprestimo.DataDevolucaoReal = DateTime.Now;

        var item = itens.FirstOrDefault(i => i.IDItem == emprestimo.IDItem);
        if (item != null) item.Disponivel = true;

        SalvarEmprestimos();
        SalvarItens();

        Console.WriteLine("✔ Devolução registrada!");
    }
}
