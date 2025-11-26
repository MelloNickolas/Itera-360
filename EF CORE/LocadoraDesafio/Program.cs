using Dominio;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Dapper;

public partial class Program
{
  public static void Main(string[] args)
  {
    int opcaoUsuario = 99;
    int confirmacao;

    using (var contexto = new Contexto())
    {
      while (opcaoUsuario != 6)
      {

        Console.WriteLine("\n================================");
        Console.WriteLine("1 - Gerenciamento de Jogos");
        Console.WriteLine("2 - Cadastro de Clientes");
        Console.WriteLine("3 - Registro de Alugueis");
        Console.WriteLine("4 - Devoluções");
        Console.WriteLine("5 - Relatórios");
        Console.WriteLine("6 - Sair");
        Console.WriteLine("Escolha uma opção: ");
        opcaoUsuario = int.Parse(Console.ReadLine());

        switch (opcaoUsuario)
        {

          case 1:
            Console.WriteLine("\n=== Gerenciamento de Jogos ===");
            Console.WriteLine("1 - Cadastrar um Novo Jogo");
            Console.WriteLine("2 - Editar Jogo Existente");
            Console.WriteLine("3 - Excluir Jogo");
            Console.WriteLine("4 - Voltar ao Menu Principal");
            Console.WriteLine("===============================");
            Console.WriteLine("Escolha uma opção: ");
            int opcaoJogo = int.Parse(Console.ReadLine());

            var jogoRepository = new JogoRepository(contexto);
            switch (opcaoJogo)
            {
              case 1:
                var jogo = new Jogo();

                Console.WriteLine("\n=== 1 - Cadastrar um Novo Jogo ===");
                Console.WriteLine("Qual o NOME do Jogo ? ");
                jogo.Nome = Console.ReadLine();

                Console.WriteLine("Qual o GENÊRO do Jogo ? ");
                jogo.Genero = Console.ReadLine();

                Console.WriteLine("Qual a PLATAFORMA do Jogo ? ");
                jogo.Plataforma = Console.ReadLine();

                Console.WriteLine("Qual a DISPONIBILIDADE do Jogo ( Disponível / Não Disponível ) ? ");
                jogo.Disponibilidade = Console.ReadLine();

                Console.WriteLine("\nVocê deseja salvar este jogo ? (1 - sim / 0 - não)");
                confirmacao = int.Parse(Console.ReadLine());

                if (confirmacao == 1)
                {
                  Console.WriteLine("Seu jogo foi CADASTRADO com sucesso ! ");
                  jogo.IDJogo = jogoRepository.CreateJogo(jogo);
                }
                else
                {
                  Console.WriteLine("Essa operação foi CANCELADA ! ");
                  continue;
                }
                break;

              case 2:
                Console.WriteLine("\n=== 2 - Editar Jogo Existente ===");
                Console.WriteLine("Qual o ID do jogo que deseja editar ? ");
                int jogoUpdateID = int.Parse(Console.ReadLine());

                var jogoUpdate = jogoRepository.GetJogoByID(jogoUpdateID);

                if (jogoUpdate != null)
                {
                  Console.WriteLine($"O nome do jogo correspondente ao ID |{jogoUpdate.IDJogo}| é {jogoUpdate.Nome}");

                  Console.WriteLine($"\nNOME atual = {jogoUpdate.Nome}");
                  Console.WriteLine("Qual o novo NOME do Jogo ? (Deixe em branco para não alterar!) ");
                  string novoNomeJogo = Console.ReadLine();
                  if (!string.IsNullOrWhiteSpace(novoNomeJogo))
                  {
                    jogoUpdate.Nome = novoNomeJogo;
                  }

                  Console.WriteLine($"\nGENÊRO atual = {jogoUpdate.Genero}");
                  Console.WriteLine("Qual o novo GENÊRO do Jogo ? (Deixe em branco para não alterar!) ");
                  string novoGeneroJogo = Console.ReadLine();
                  if (!string.IsNullOrWhiteSpace(novoGeneroJogo))
                  {
                    jogoUpdate.Genero = novoGeneroJogo;
                  }

                  Console.WriteLine($"\nPLATAFORMA atual = {jogoUpdate.Plataforma}");
                  Console.WriteLine("Qual a nova PLATAFORMA do Jogo ? (Deixe em branco para não alterar!) ");
                  string novaPlataformaJogo = Console.ReadLine();
                  if (!string.IsNullOrWhiteSpace(novaPlataformaJogo))
                  {
                    jogoUpdate.Plataforma = novaPlataformaJogo;
                  }

                  Console.WriteLine($"\nDISPONIBILIDADE atual = {jogoUpdate.Disponibilidade}");
                  Console.WriteLine("Qual a nova DISPONIBILIDADE do Jogo ( Disponível / Não Disponível ) ? (Deixe em branco para não alterar!) ");
                  string novaDisponibildadeJogo = Console.ReadLine();
                  if (!string.IsNullOrWhiteSpace(novaDisponibildadeJogo))
                  {
                    jogoUpdate.Disponibilidade = novaDisponibildadeJogo;
                  }

                  Console.WriteLine("\nVocê deseja salvar os novos dados deste jogo ? (1 - sim / 0 - não)");
                  confirmacao = int.Parse(Console.ReadLine());

                  if (confirmacao == 1)
                  {
                    Console.WriteLine("Seu jogo foi SALVO com sucesso ! ");
                    jogoRepository.UpdateJogo(jogoUpdate);
                  }
                  else
                  {
                    Console.WriteLine("Essa operação foi CANCELADA ! ");
                  }

                }
                else
                {
                  Console.WriteLine($"\nNão foi encontrado nenhum jogo pelo ID !");
                  continue;
                }
                break;

              case 3:
                Console.WriteLine("\n=== 3 - Excluir Jogo ===");
                Console.WriteLine("Qual o ID do jogo que deseja excluir ? ");
                int jogoDeletarID = int.Parse(Console.ReadLine());

                var jogoDeletar = jogoRepository.GetJogoByID(jogoDeletarID);

                if (jogoDeletar != null)
                {
                  Console.WriteLine($"\n=== {jogoDeletar.Nome} ===");
                  Console.WriteLine($"=== {jogoDeletar.Genero} ===");
                  Console.WriteLine($"=== {jogoDeletar.Plataforma} ===");
                  Console.WriteLine($"=== {jogoDeletar.Disponibilidade} ===");

                }
                else
                {
                  Console.WriteLine($"\nNão foi encontrado nenhum jogo pelo ID !");
                  continue;
                }

                Console.WriteLine("\nVocê deseja DELETAR este jogo ? (1 - sim / 0 - não)");
                confirmacao = int.Parse(Console.ReadLine());

                if (confirmacao == 1)
                {
                  Console.WriteLine("Seu jogo foi DELETADO com sucesso ! ");
                  jogoRepository.DeleteJogoByID(jogoDeletarID);
                }
                else
                {
                  Console.WriteLine("Essa operação foi CANCELADA ! ");
                  continue;
                }
                continue;

              case 4:
                Console.WriteLine("\nSaindo do GERENCIAMENTO DE JOGOS !");
                break;

              default:
                Console.WriteLine("\n=== OPÇÃO INVÁLIDA ===");
                continue;

            }
            break;

          case 2:
            Console.WriteLine("\n=== Cadastro de Clientes ===");
            Console.WriteLine("1 - Cadastrar um Novo Cliente");
            Console.WriteLine("2 - Editar um Cliente Existente");
            Console.WriteLine("3 - Excluir Cliente");
            Console.WriteLine("4 - Voltar ao Menu Principal");
            Console.WriteLine("===============================");

            Console.WriteLine("Escolha uma opção: ");
            int opcaoCliente = int.Parse(Console.ReadLine());

            var clienteRepository = new ClienteRepository(contexto);
            switch (opcaoCliente)
            {
              case 1:
                var cliente = new Cliente();

                Console.WriteLine("\n=== 1 - Cadastrar um Novo Cliente ===");
                Console.WriteLine("Qual o NOME do cliente ? ");
                cliente.Nome = Console.ReadLine();

                Console.WriteLine("Qual o EMAIL do cliente ? ");
                cliente.Email = Console.ReadLine();

                Console.WriteLine("Qual a TELEFONE do cliente ? (xx)xxxxx-xxxx");
                cliente.Telefone = Console.ReadLine();


                Console.WriteLine("\nVocê deseja CADASTRAR esse cliente ? (1 - sim / 0 - não)");
                confirmacao = int.Parse(Console.ReadLine());

                if (confirmacao == 1)
                {
                  Console.WriteLine("Seu Cliente foi CADASTRADO com sucesso ! ");
                  cliente.IDCliente = clienteRepository.CreateCliente(cliente);
                }
                else
                {
                  Console.WriteLine("Essa operação foi CANCELADA ! ");
                  continue;
                }
                break;

              case 2:
                Console.WriteLine("\n=== 2 - Editar um Cliente Existente ===");
                Console.WriteLine("Qual o ID do cliente que deseja editar ? ");
                int clienteUpdateID = int.Parse(Console.ReadLine());

                var clienteUpdate = clienteRepository.GetClienteByID(clienteUpdateID);

                if (clienteUpdate != null)
                {
                  Console.WriteLine($"O nome do cliente correspondente ao ID |{clienteUpdate.IDCliente}| é {clienteUpdate.Nome}");

                  Console.WriteLine($"\nNOME atual = {clienteUpdate.Nome}");
                  Console.WriteLine("Qual o novo NOME do cliente ? (Deixe em branco para não alterar!) ");
                  string novoNomeCliente = Console.ReadLine();
                  if (!string.IsNullOrWhiteSpace(novoNomeCliente))
                  {
                    clienteUpdate.Nome = novoNomeCliente;
                  }

                  Console.WriteLine($"\nEMAIL atual = {clienteUpdate.Email}");
                  Console.WriteLine("Qual o novo EMAIL do cliente ? (Deixe em branco para não alterar!) ");
                  string novoEmailCliente = Console.ReadLine();
                  if (!string.IsNullOrWhiteSpace(novoEmailCliente))
                  {
                    clienteUpdate.Email = novoEmailCliente;
                  }

                  Console.WriteLine($"\nTELEFONE atual = {clienteUpdate.Telefone}");
                  Console.WriteLine("Qual o novo TELEFONE do cliente ? (Deixe em branco para não alterar!) ");
                  string novoTelefoneCliente = Console.ReadLine();
                  if (!string.IsNullOrWhiteSpace(novoTelefoneCliente))
                  {
                    clienteUpdate.Telefone = novoTelefoneCliente;
                  }

                  Console.WriteLine("\nVocê deseja salvar os novos dados deste cliente ? (1 - sim / 0 - não)");
                  confirmacao = int.Parse(Console.ReadLine());

                  if (confirmacao == 1)
                  {
                    Console.WriteLine("Seu cliente foi ATUALIZADO com sucesso ! ");
                    clienteRepository.UpdateCliente(clienteUpdate);
                  }
                  else
                  {
                    Console.WriteLine("Essa operação foi CANCELADA ! ");
                  }

                }
                else
                {
                  Console.WriteLine($"\nNão foi encontrado nenhum CLIENTE pelo ID !");
                  continue;
                }

                break;

              case 3:
                Console.WriteLine("\n=== 3 - Excluir Cliente ===");
                Console.WriteLine("Qual o ID do cliente que deseja excluir ? ");
                int clienteDeletarID = int.Parse(Console.ReadLine());

                var clienteDeletar = clienteRepository.GetClienteByID(clienteDeletarID);

                if (clienteDeletar != null)
                {
                  Console.WriteLine($"\n=== {clienteDeletar.Nome} ===");
                  Console.WriteLine($"=== {clienteDeletar.Email} ===");
                  Console.WriteLine($"=== {clienteDeletar.Telefone} ===");
                }
                else
                {
                  Console.WriteLine($"\nNão foi encontrado nenhum cliente pelo ID !");
                  continue;
                }

                Console.WriteLine("\nVocê deseja DELETAR este jogo ? (1 - sim / 0 - não)");
                confirmacao = int.Parse(Console.ReadLine());

                if (confirmacao == 1)
                {
                  Console.WriteLine("Seu cliente foi DELETADO com sucesso ! ");
                  clienteRepository.DeleteClienteByID(clienteDeletarID);
                }
                else
                {
                  Console.WriteLine("Essa operação foi CANCELADA ! ");
                  continue;
                }
                break;

              case 4:
                Console.WriteLine("\nSaindo do CADASTRO DE CLIENTES !");
                break;

              default:
                Console.WriteLine("\n=== OPÇÃO INVÁLIDA ===");
                continue;
            }
            break;

          case 3:
            Console.WriteLine("\n=== Cadastro de Alugueis ===");
            Console.WriteLine("1 - Cadastrar um Novo Aluguel");
            Console.WriteLine("2 - Editar um Aluguel Existente");
            Console.WriteLine("3 - Excluir Aluguel");
            Console.WriteLine("4 - Voltar ao Menu Principal");
            Console.WriteLine("===============================");
            Console.WriteLine("Escolha uma opção: ");
            int opcaoAluguel = int.Parse(Console.ReadLine());

            var aluguelRepository = new AluguelRepository(contexto);
            switch (opcaoAluguel)
            {
              case 1:
                var novoAluguel = new Aluguel();

                Console.WriteLine("Informe o ID do cliente para este aluguel: ");
                novoAluguel.IDCliente = int.Parse(Console.ReadLine());

                Console.WriteLine("Informe a data do aluguel (AAAA-MM-DD): ");
                novoAluguel.DataAluguel = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Informe a data de devolução (AAAA-MM-DD) ou deixe vazio se ainda não devolveu:");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                  novoAluguel.DataDevolucao = null; // Ainda não devolvido
                }
                else
                {
                  novoAluguel.DataDevolucao = DateTime.Parse(input);
                }

                Console.WriteLine("Quantos jogos deseja alugar?");
                int qtdJogos = int.Parse(Console.ReadLine());

                for (int i = 0; i < qtdJogos; i++)
                {
                  Console.WriteLine($"Informe o ID do {i + 1}* jogo : ");
                  int idJogo = int.Parse(Console.ReadLine());
                  novoAluguel.Jogos.Add(new Jogo { IDJogo = idJogo });
                }

                Console.WriteLine("\nDeseja salvar este aluguel? (1 - sim / 0 - não)");
                confirmacao = int.Parse(Console.ReadLine());

                if (confirmacao == 1)
                {
                  aluguelRepository.CreateAluguel(novoAluguel);
                  Console.WriteLine($"Aluguel cadastrado com sucesso!");
                }
                else
                {
                  Console.WriteLine("Essa operação foi CANCELADA ! ");
                }
                break;

              case 2:
                Console.WriteLine("Informe o ID do aluguel que deseja editar: ");
                int idAluguelUpdate = int.Parse(Console.ReadLine());

                var aluguelUpdate = aluguelRepository.GetAluguelByID(idAluguelUpdate);

                if (aluguelUpdate == null)
                {
                  Console.WriteLine("Aluguel não encontrado.");
                  break;
                }

                Console.WriteLine($"Data do aluguel atual: {aluguelUpdate.DataAluguel:yyyy-MM-dd}");
                Console.WriteLine("Nova data do aluguel (deixe em branco para não alterar): ");
                string novaDataAluguel = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novaDataAluguel))
                  aluguelUpdate.DataAluguel = DateTime.Parse(novaDataAluguel);

                Console.WriteLine($"Data de devolução atual: {aluguelUpdate.DataDevolucao:yyyy-MM-dd}");
                Console.WriteLine("Nova data de devolução (deixe em branco para não alterar): ");
                string novaDataDevolucao = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novaDataDevolucao))
                  aluguelUpdate.DataDevolucao = DateTime.Parse(novaDataDevolucao);

                // Atualizar jogos
                Console.WriteLine("Deseja alterar os jogos? (1 - sim / 0 - não)");
                int alterarJogos = int.Parse(Console.ReadLine());
                if (alterarJogos == 1)
                {
                  aluguelUpdate.Jogos.Clear(); //limpar a lista para adicionar os outros jogos
                  Console.WriteLine("Quantos jogos deseja alugar?");
                  int qtdJogosEdit = int.Parse(Console.ReadLine());

                  for (int i = 0; i < qtdJogosEdit; i++)
                  {
                    Console.WriteLine($"Informe o ID do jogo #{i + 1}: ");
                    int idJogo = int.Parse(Console.ReadLine());
                    aluguelUpdate.Jogos.Add(new Jogo { IDJogo = idJogo });
                  }
                }

                Console.WriteLine("Deseja salvar as alterações? (1 - sim / 0 - não)");
                confirmacao = int.Parse(Console.ReadLine());

                if (confirmacao == 1)
                {
                  aluguelRepository.UpdateAluguel(aluguelUpdate);
                  Console.WriteLine("Aluguel atualizado com sucesso!");
                }
                else
                {
                  Console.WriteLine("Essa operação foi CANCELADA ! ");
                }
                break;

              case 3:
                Console.WriteLine("Informe o ID do aluguel que deseja excluir: ");
                int idAluguelDelete = int.Parse(Console.ReadLine());

                Console.WriteLine("Tem certeza que deseja excluir este aluguel? (1 - sim / 0 - não)");
                confirmacao = int.Parse(Console.ReadLine());

                if (confirmacao == 1)
                {
                  aluguelRepository.DeleteAluguelByID(idAluguelDelete);
                  Console.WriteLine("Aluguel excluído com sucesso!");
                }
                else
                {
                  Console.WriteLine("Operação cancelada.");
                }
                break;

              case 4:
                Console.WriteLine("Saindo do CADASTRO DE ALUGUEIS");
                break;

              default:
                Console.WriteLine("=== OPÇÃO INVALIDA ===");
                break;
            }
            break;

          case 4:
            var aluguelRepositoryDevolucao = new AluguelRepository(contexto);

            Console.Write("\nInforme o ID do aluguel que deseja devolver: ");
            int idAluguelDevolucao = int.Parse(Console.ReadLine());

            var aluguelDevolucao = aluguelRepositoryDevolucao.GetAluguelByID(idAluguelDevolucao);

            if (aluguelDevolucao == null)
            {
              Console.WriteLine("Aluguel não encontrado.");
              break;
            }

            // Verifica se já foi devolvido, vamos verificar isso vendo se a data de hoje é maior que a data de antes
            if (aluguelDevolucao.DataDevolucao <= DateTime.Today)
            {
              Console.WriteLine($"Este aluguel já foi devolvido em {aluguelDevolucao.DataDevolucao:yyyy-MM-dd}.");
              break;
            }

            Console.WriteLine("\nDeseja salvar esta DEVOLUÇÃO? (1 - sim / 0 - não)");
            confirmacao = int.Parse(Console.ReadLine());

            if (confirmacao == 1)
            {
              // Atualiza a data de devolução
              aluguelDevolucao.DataDevolucao = DateTime.Today;
              aluguelRepositoryDevolucao.UpdateAluguel(aluguelDevolucao);
              Console.WriteLine($"Aluguel ID {idAluguelDevolucao} devolvido com sucesso! Data da dvolução: {aluguelDevolucao.DataDevolucao:yyyy-MM-dd}");
            }
            else
            {
              Console.WriteLine("Essa operação foi CANCELADA ! ");
            }
            break;

          case 5:
            Console.WriteLine("\n=== RELATORIOS ==");
            Console.WriteLine("1 - TOP10 mais alugados");
            Console.WriteLine("2 - TOP10 clientes que mais alugam");
            Console.WriteLine("3 - Todos os jogos que não estão disponiveis");
            Console.WriteLine("4 - Todos os jogos que estão disponiveis");
            Console.WriteLine("5 - Todos os alugueis atrasados");
            Console.WriteLine("6 - Voltar ao Menu");
            Console.WriteLine("===============================");
            Console.WriteLine("Escolha uma opção: ");
            int opcaoRelatorios = int.Parse(Console.ReadLine());

            var conexao = contexto.Database.GetDbConnection(); //vamos usar para fazer as conexoes com o banco usando dapper
            switch (opcaoRelatorios)
            {
              case 1:
                Console.WriteLine("\n=== TOP 10 JOGOS MAIS ALUGADOS ===");

                var sqlTopJogos = @"
               SELECT TOP 10
                Jogos.IDJogo,
                Jogos.Nome,
                COUNT(Jogos.IDAluguel) AS QuantidadeAlugueis
              FROM Jogos
              WHERE Jogos.IDAluguel IS NOT NULL
              GROUP BY Jogos.IDJogo, Jogos.Nome
              ORDER BY QuantidadeAlugueis DESC;
                ";

                var topJogos = conexao.Query(sqlTopJogos);
                foreach (var jogos in topJogos)
                {
                  Console.WriteLine($"{jogos.Nome} - {jogos.QuantidadeAlugueis}x");
                }
                break;

              case 2:
                Console.WriteLine("=== TOP 10 CLIENTES QUE MAIS ALUGAM ===");

                var sqlTopClientes = @"
                SELECT TOP 10
                    Clientes.IDCliente,
                    Clientes.Nome,
                    COUNT(Alugueis.IDAluguel) AS QuantidadeAlugueis
                FROM Alugueis
                INNER JOIN Clientes ON Clientes.IDCliente = Alugueis.IDCliente
                GROUP BY Clientes.IDCliente, Clientes.Nome
                ORDER BY QuantidadeAlugueis DESC;
                ";
                var topClientes = conexao.Query(sqlTopClientes);
                foreach (var cliente in topClientes)
                {
                  Console.WriteLine($"ID: {cliente.IDCliente} | Nome: {cliente.Nome} | Aluguéis: {cliente.QuantidadeAlugueis}");
                }
                break;

              case 3:
                Console.WriteLine("=== JOGOS NÃO DISPONÍVEIS ===");
                var sqlJogosAlugados = @"
                SELECT
                  Jogos.IDJogo,
                  Jogos.Nome AS NomeDoJogo,
                  Clientes.IDCliente,
                  Clientes.Nome AS NomeDoCliente,
                  Alugueis.IDAluguel,
                  Alugueis.DataAluguel,
                  Alugueis.DataDevolucao
                FROM Jogos
                INNER JOIN Alugueis
                  ON Jogos.IDAluguel = Alugueis.IDAluguel
                INNER JOIN Clientes
                  ON Clientes.IDCliente = Alugueis.IDCliente
                WHERE 
                  Alugueis.DataDevolucao IS NULL
                  OR Alugueis.DataDevolucao > GETDATE();
                ";

                var jogosIndisponiveis = conexao.Query(sqlJogosAlugados);
                foreach (var jogo in jogosIndisponiveis)
                {
                  Console.WriteLine($"ID: {jogo.IDJogo} | Nome: {jogo.Nome} | Aluguel: {jogo.IDAluguel} | Data Aluguel: {jogo.DataAluguel}");
                }
                break;

              case 4:
                Console.WriteLine("=== JOGOS DISPONÍVEIS ===");

                var sqlDisponiveis = @"
                SELECT 
                  IDJogo,
                  Nome,
                  Genero,
                  Plataforma,
                  Disponibilidade
                FROM Jogos
                WHERE Disponibilidade = 'Disponivel';
                ";

                var jogosDisponiveis = conexao.Query(sqlDisponiveis);

                foreach (var jogos in jogosDisponiveis)
                {
                  Console.WriteLine($"ID: {jogos.IDJogo} | Nome: {jogos.Nome}");
                }
                break;

              case 5:

                Console.WriteLine("=== ALUGUÉIS ATRASADOS ===");

                var sqlAtrasados = @"
                SELECT 
                  Alugueis.IDAluguel,
                  Alugueis.DataAluguel,
                  Alugueis.DataDevolucao,
                  Clientes.IDCliente,
                  Clientes.Nome AS NomeCliente,
                  Jogos.IDJogo,
                  Jogos.Nome AS NomeJogo
                FROM Alugueis
                INNER JOIN Clientes ON Clientes.IDCliente = Alugueis.IDCliente
                INNER JOIN Jogos ON Jogos.IDAluguel = Alugueis.IDAluguel
                WHERE 
                 Alugueis.DataDevolucao < GETDATE()
                  AND Jogos.IDAluguel IS NOT NULL; 
                ";
                var atrasados = conexao.Query(sqlAtrasados);

                foreach (var aluguel in atrasados)
                {
                  Console.WriteLine(
                      $"ID Aluguel: {aluguel.IDAluguel} | Cliente: {aluguel.NomeCliente} | Jogo: {aluguel.NomeJogo} | " +
                      $"Alugado em: {aluguel.DataAluguel} | Previsto para: {aluguel.DataDevolucao}"
                  );
                }
                break;

              case 6:
                Console.WriteLine("Saindo dos RELATORIOS");
                break;

              default:
                Console.WriteLine("Opção inválida!");
                break;
            }
            break;

          case 6:
            Console.WriteLine("ENCERRANDO O PROGRAMA...");
            break;

          default:
            Console.WriteLine("OPÇÃO INVÁLIDA");
            break;
        }
      }
    }
  }
}