Dictionary<string, string> AgendaTelefonica = new Dictionary<string, string>();

int opcao = 0;

do
{
  Console.WriteLine();
  Console.WriteLine("\nAGENDA TELEFONICA");
  Console.WriteLine("1 - Inserir contato");
  Console.WriteLine("2 - Remover contato");
  Console.WriteLine("3 - Consultar contato");
  Console.WriteLine("4 - Finalizar programa");
  opcao = int.Parse(Console.ReadLine()!);
  Console.WriteLine();

  switch (opcao)
  {
    case 1:
      Console.WriteLine("Qual o nome deseja salvar o contato? ");
      string nomeContato = Console.ReadLine()!;

      Console.WriteLine($"Qual o telefone do/da {nomeContato}? ");
      string telefoneContato = Console.ReadLine()!;

      if (AgendaTelefonica.ContainsKey(nomeContato))
      {
        Console.WriteLine("Esse contato já esta cadastrado!, iremos atualizar o seu número!");
        AgendaTelefonica[nomeContato] = telefoneContato;
      }
      else
      {
        AgendaTelefonica.Add(nomeContato, telefoneContato);
        Console.WriteLine("Contato Registrado!");
      }
      break;

    case 2:
      if (AgendaTelefonica.Count == 0)
      {
        Console.WriteLine("Não é possível remover pois não possui nenhum contato!");
        break;
      }

      Console.WriteLine("Qual o nome do contato que você deseja remover? ");
      string nomeRemover = Console.ReadLine()!;

      if (AgendaTelefonica.ContainsKey(nomeRemover))
      {
        AgendaTelefonica.Remove(nomeRemover);
        Console.WriteLine("Contato removido com sucesso!");
      }
      else
      {
        Console.WriteLine("Contato não encontrado!");
      }
      break;

    case 3:
      if (AgendaTelefonica.Count == 0)
      {
        Console.WriteLine("Não é possível CONSULTAR pois não possui nenhum contato!");
        break;
      }

      Console.WriteLine("Qual o nome do contato que você deseja consultar? ");
      string nomeConsulta = Console.ReadLine()!;

      if (AgendaTelefonica.ContainsKey(nomeConsulta))
      {
        Console.WriteLine($"Contato {nomeConsulta} - {AgendaTelefonica[nomeConsulta]}");
      }
      else
      {
        Console.WriteLine("Contato não encontrado!");
      }
      break;

    case 4:
      break;

    default:
      Console.WriteLine("Opção inválida!");
      break;
  }
} while (opcao != 4);

Console.WriteLine("----------------- PROGRAMA FINALIZADO -----------------");