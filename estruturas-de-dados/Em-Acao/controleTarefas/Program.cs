string[] tarefas = new string[10];
bool[] concluida = new bool[10];
int quantidadeTarefas = 0;

void AdicionarTarefa()
{
  if (quantidadeTarefas >= 10)
  {
    Console.WriteLine("--- A LISTA DE TAREFAS ESTÁ CHEIA ---\n");
    return;
  }

  Console.Write("--- Descreva a tarefa: ");
  string descricao = Console.ReadLine()!;

  tarefas[quantidadeTarefas] = descricao;
  concluida[quantidadeTarefas] = false; // nao é concluida ao adicionar
  quantidadeTarefas++;
  Console.WriteLine("--- Tarefa adicionada com sucesso! ---\n");
}

void ConcluirTarefa()
{
  if (quantidadeTarefas == 0)
  {
    Console.WriteLine("--- NÃO EXISTEM TAREFAS PARA CONCLUIR ---\n");
    return;
  }

  ListarTarefas();

  Console.Write("--- Digite o número da tarefa para marcar como concluída: ");
  int numero = int.Parse(Console.ReadLine()!);

  if (numero < 1 || numero > quantidadeTarefas)
  {
    Console.WriteLine("--- NÚMERO INVÁLIDO ---\n");
    return;
  }

  if (concluida[numero - 1])
  {
    Console.WriteLine("--- ESSA TAREFA JÁ ESTÁ CONCLUÍDA ---\n");
    return;
  }

  concluida[numero - 1] = true; // conclui a tarefa se digitar 1 ele conclui do indice 0
  Console.WriteLine($"--- Tarefa {numero} marcada como concluída! ---\n");
}

void ListarTarefas()
{
  if (quantidadeTarefas == 0)
  {
    Console.WriteLine("--- NÃO HÁ TAREFAS CADASTRADAS ---\n");
    return;
  }

  Console.WriteLine("--- LISTA DE TAREFAS ---");
  for (int i = 0; i < quantidadeTarefas; i++)
  {
    string status = concluida[i] ? "Concluída" : "Pendente";
    Console.WriteLine($"[{i + 1}] {tarefas[i]} - {status}");
  }
  Console.WriteLine();
}

bool encerrar = false;

while (!encerrar)
{
  Console.WriteLine("\n--- GERENCIADOR DE TAREFAS ---");
  Console.WriteLine("1 - Adicionar tarefa");
  Console.WriteLine("2 - Concluir tarefa");
  Console.WriteLine("3 - Listar tarefas");
  Console.WriteLine("4 - Sair");
  Console.Write("Escolha uma opção: ");

  string opcao = Console.ReadLine()!;

  switch (opcao)
  {
    case "1":
      AdicionarTarefa();
      break;
    case "2":
      ConcluirTarefa();
      break;
    case "3":
      ListarTarefas();
      break;
    case "4":
      encerrar = true;
      Console.WriteLine("Saindo do programa...");
      break;
    default:
      Console.WriteLine("--- OPÇÃO INVÁLIDA ---");
      break;
  }
}
