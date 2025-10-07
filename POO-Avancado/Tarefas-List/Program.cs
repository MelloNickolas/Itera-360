List<string> ListaTarefas = new List<string>();

int opcao = 0;

do
{
  Console.WriteLine();
  Console.WriteLine("\nLISTA DE TAREFAS");
  Console.WriteLine("1 - Adicionar Tarefa");
  Console.WriteLine("2 - Remover Tarefa");
  Console.WriteLine("3 - Ver Tarefas");
  Console.WriteLine("4 - Finalizar programa");
  opcao = int.Parse(Console.ReadLine()!);
  Console.WriteLine();

  switch (opcao)
  {
    case 1:
      Console.WriteLine("Qual a TAREFA você deseja adicionar? ");
      string tarefa = Console.ReadLine()!;


      if (ListaTarefas.Contains(tarefa))
      {
        Console.WriteLine("Essa Tarefa já existe!");
        break;
      }
      else
      {
        ListaTarefas.Add(tarefa);
        Console.WriteLine("Tarefa Registrada!");
      }
      break;

    case 2:
      if (ListaTarefas.Count == 0)
      {
        Console.WriteLine("Não é possível REMOVER pois não possui nenhuma TAREFA!");
        break;
      }

      Console.WriteLine("Qual o nome da TAREFA que você deseja remover?");
      string tarefaRemover = Console.ReadLine()!;

      if (tarefaRemover.Contains(tarefaRemover))
      {
        ListaTarefas.Remove(tarefaRemover);
        Console.WriteLine("Tarefa removida com Sucesso!");
      }
      else
      {
        Console.WriteLine("Tarefa não encontrada!");
      }
      break;

    case 3:
      if (ListaTarefas.Count == 0)
      {
        Console.WriteLine("Não é possível CONSULTAR pois não possui nenhuma!");
        break;
      }
      
      foreach (var i in ListaTarefas)
      {
        Console.WriteLine($"Tarefa - {i}");
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