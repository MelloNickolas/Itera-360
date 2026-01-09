using Services;
using Dominio;

class Program
{
  static async Task Main(string[] args)
  {
    HttpClient client = new HttpClient();
    PacienteService pacienteService = new PacienteService(client);

    bool sair = false;

    while (!sair)
    {
      Console.WriteLine("\n=== MENU PACIENTES ===");
      Console.WriteLine("1 - Listar Pacientes");
      Console.WriteLine("2 - Adicionar Paciente");
      Console.WriteLine("3 - Registrar Consulta");
      Console.WriteLine("4 - Dar Alta");
      Console.WriteLine("5 - Remover Paciente");
      Console.WriteLine("0 - Sair");
      Console.Write("Escolha uma opção: ");

      string? opcao = Console.ReadLine();
      Console.WriteLine();

      try
      {
        switch (opcao)
        {
          case "1":
            var pacientes = await pacienteService.GetPacientesAsync();

            if (pacientes.Count == 0)
            {
              Console.WriteLine("Nenhum paciente cadastrado.");
            }
            else
            {
              foreach (var p in pacientes)
              {
                Console.WriteLine(
                  $"ID: {p.IDPaciente} | Nome: {p.Nome} | Nasc: {p.DataNascimento:dd/MM/yyyy} | Ativo: {(p.Ativo ? "Sim" : "Não")}"
                );
              }
            }
            break;

          case "2":
            Console.Write("Nome do paciente: ");
            string nome = Console.ReadLine();

            Console.Write("Qual sua data de nascimento: ");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());

            Console.Write("Paciente está ativo? (true/false): ");
            bool ativo = bool.Parse(Console.ReadLine());

            var novoPaciente = new Paciente
            {
              Nome = nome,
              DataNascimento = dataNascimento,
              Ativo = ativo
            };

            int idCriado = await pacienteService.AddPacienteAsync(novoPaciente);
            Console.WriteLine($"Paciente criado com ID {idCriado}");
            break;

          case "3":
            Console.Write("ID do paciente para registrar consulta: ");
            int idConsultar = int.Parse(Console.ReadLine());

            if (await pacienteService.ConsultarAsync(idConsultar))
              Console.WriteLine("Consulta registrada com sucesso!");
            else
              Console.WriteLine("Não foi possível registrar a consulta (verifique o ID).");
            break;

          case "4":
            Console.Write("ID do paciente para dar alta: ");
            int idAlta = int.Parse(Console.ReadLine());

            if (await pacienteService.AltaAsync(idAlta))
              Console.WriteLine("Alta registrada com sucesso!");
            else
              Console.WriteLine("Não foi possível dar alta (verifique o ID).");
            break;

          case "5":
            Console.Write("ID do paciente para remover: ");
            int idRemover = int.Parse(Console.ReadLine());

            if (await pacienteService.DeletePacienteAsync(idRemover))
              Console.WriteLine("Paciente removido com sucesso!");
            else
              Console.WriteLine("Não foi possível remover o paciente (verifique o ID).");
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
