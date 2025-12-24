using Services;
using Dominio;

class Program
{
  static async Task Main(string[] args)
  {
    HttpClient client = new HttpClient();
    JogoService jogoService = new JogoService(client);

    bool sair = false;

    while (!sair)
    {
      Console.WriteLine("\n=== MENU PRINCIPAL ===");
      Console.WriteLine("1 - Listar Jogos");
      Console.WriteLine("2 - Adicionar Jogo");
      Console.WriteLine("3 - Alugar Jogo");
      Console.WriteLine("4 - Devolver Jogo");
      Console.WriteLine("5 - Remover Jogo");
      Console.WriteLine("0 - Sair");
      Console.Write("Escolha uma opção: ");

      string? opcao = Console.ReadLine();
      Console.WriteLine();

      try
      {
        switch (opcao)
        {
          case "1":
            var jogos = await jogoService.GetJogosAsync();

            if (jogos.Count == 0)
            {
              Console.WriteLine("Nenhum jogo cadastrado.");
            }
            else
            {
              foreach (var jogo in jogos)
              {
                Console.WriteLine($"ID: {jogo.IDJogo} | Nome: {jogo.Nome} | Alugado: {jogo.Alugado}");
              }
            }
            break;



          case "2":
            Console.Write("Nome do jogo: ");
            string nome = Console.ReadLine() ?? "";

            var novoJogo = new Jogo
            {
              Nome = nome,
              Alugado = false
            };

            int idCriado = await jogoService.AddJogoAsync(novoJogo);
            Console.WriteLine($"Jogo criado com ID {idCriado}");
            break;




          case "3":
            Console.Write("ID do jogo para alugar: ");
            int idAlugar = int.Parse(Console.ReadLine()!);

            if (await jogoService.AlugarJogoAsync(idAlugar))
              Console.WriteLine("Jogo alugado com sucesso!");
            else
              Console.WriteLine("Não foi possível alugar o jogo.");
            break;




          case "4":
            Console.Write("ID do jogo para devolver: ");
            int idDevolver = int.Parse(Console.ReadLine()!);

            if (await jogoService.DevolverJogoAsync(idDevolver))
              Console.WriteLine("Jogo devolvido com sucesso!");
            else
              Console.WriteLine("Não foi possível devolver o jogo.");
            break;




          case "5":
            Console.Write("ID do jogo para remover: ");
            int idRemover = int.Parse(Console.ReadLine()!);

            if (await jogoService.DeleteJogoAsync(idRemover))
              Console.WriteLine("Jogo removido com sucesso!");
            else
              Console.WriteLine("Não foi possível remover o jogo.");
            break;




          case "0":
            sair = true;
            Console.WriteLine("Encerrando aplicação...");
            break;




          default:
            Console.WriteLine("Opção inválida.");
            break;
        }
      }
      catch (HttpRequestException e)
      {
        Console.WriteLine("Erro ao fazer chamada de API: " + e.Message);
      }
      catch (Exception e)
      {
        Console.WriteLine("Erro: " + e.Message);
      }
    }
  }
}
