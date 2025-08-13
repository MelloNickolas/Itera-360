string[] aulas = new string[10];
int quantidadeAulas = 0;

void AdicionarAula()
{
  if (quantidadeAulas >= 10)
  {
    Console.WriteLine("--- O DIÁRIO DE AULAS ESTÁ CHEIO ---\n");
    return;
  }

  Console.Write("--- Nome da aula: ");
  string nome = Console.ReadLine()!;

  aulas[quantidadeAulas] = nome;
  quantidadeAulas++;
  Console.WriteLine("--- Aula adicionada com sucesso! ---\n");
}

void RemoverAula()
{
  if (quantidadeAulas == 0)
  {
    Console.WriteLine("--- NÃO EXISTEM AULAS REGISTRADAS ---\n");
    return;
  }

  Console.WriteLine("--- AULAS REGISTRADAS ---");
  for (int i = 0; i < quantidadeAulas; i++)
  {
    Console.WriteLine($"-{i + 1}- {aulas[i]}");
  }

  Console.Write("--- Digite o nome da aula para remover: ");
  string nomeParaRemover = Console.ReadLine()!;
  int indiceParaRemover = -1;

  for (int i = 0; i < quantidadeAulas; i++)
  {
    if (aulas[i].Equals(nomeParaRemover, StringComparison.OrdinalIgnoreCase))
    {
      indiceParaRemover = i;
      break;
    }
  }

  if (indiceParaRemover == -1)
  {
    Console.WriteLine("--- AULA NÃO ENCONTRADA ---\n");
    return;
  }

  for (int i = indiceParaRemover; i < quantidadeAulas - 1; i++)
  {
    aulas[i] = aulas[i + 1];
  }

  quantidadeAulas--;
  Console.WriteLine($"--- Aula \"{nomeParaRemover}\" removida com sucesso! ---\n");
}

void ListarAulas()
{
  if (quantidadeAulas == 0)
  {
    Console.WriteLine("--- NENHUMA AULA REGISTRADA ---\n");
    return;
  }

  Console.WriteLine("--- LISTA DE AULAS ---");
  for (int i = 0; i < quantidadeAulas; i++)
  {
    Console.WriteLine($"[{i + 1}] {aulas[i]}");
  }
  Console.WriteLine();
}

bool encerrar = false;

while (!encerrar)
{
  Console.WriteLine("\n--- DIÁRIO DE AULAS ---");
  Console.WriteLine("1 - Adicionar aula");
  Console.WriteLine("2 - Remover aula");
  Console.WriteLine("3 - Listar aulas");
  Console.WriteLine("4 - Sair");
  Console.Write("Escolha uma opção: ");

  string opcao = Console.ReadLine()!;

  switch (opcao)
  {
    case "1":
      AdicionarAula();
      break;
    case "2":
      RemoverAula();
      break;
    case "3":
      ListarAulas();
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
