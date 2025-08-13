string[] itens = new string[10];
int quantidadeItens = 0;

void AdicionarItem()
{
  if (quantidadeItens >= 10)
  {
    Console.WriteLine("--- A LISTA DE COMPRAS ESTÁ CHEIA ---\n");
    return;
  }

  Console.Write("--- Nome do item: ");
  string nome = Console.ReadLine()!;

  itens[quantidadeItens] = nome;
  quantidadeItens++;
  Console.WriteLine("--- Item adicionado com sucesso! ---\n");
}

void RemoverItem()
{
  if (quantidadeItens == 0)
  {
    Console.WriteLine("--- NÃO EXISTEM ITENS NA LISTA ---\n");
    return;
  }

  Console.WriteLine("--- ITENS NA LISTA ---");
  for (int i = 0; i < quantidadeItens; i++)
  {
    Console.WriteLine($"-{i + 1}- {itens[i]}");
  }

  Console.Write("--- Digite o nome do item para remover: ");
  string nomeParaRemover = Console.ReadLine()!;
  int indiceParaRemover = -1;

  for (int i = 0; i < quantidadeItens; i++)
  {
    if (itens[i].Equals(nomeParaRemover, StringComparison.OrdinalIgnoreCase))
    {
      indiceParaRemover = i;
      break;
    }
  }

  if (indiceParaRemover == -1)
  {
    Console.WriteLine("--- ITEM NÃO ENCONTRADO ---\n");
    return;
  }

  for (int i = indiceParaRemover; i < quantidadeItens - 1; i++)
  {
    itens[i] = itens[i + 1];
  }

  quantidadeItens--;
  Console.WriteLine($"--- Item \"{nomeParaRemover}\" removido com sucesso! ---\n");
}

void ListarItens()
{
  if (quantidadeItens == 0)
  {
    Console.WriteLine("--- A LISTA DE COMPRAS ESTÁ VAZIA ---\n");
    return;
  }

  Console.WriteLine("--- ITENS NA LISTA DE COMPRAS ---");
  for (int i = 0; i < quantidadeItens; i++)
  {
    Console.WriteLine($"[{i + 1}] {itens[i]}");
  }
  Console.WriteLine();
}

bool encerrar = false;

while (!encerrar)
{
  Console.WriteLine("\n--- LISTA DE COMPRAS ---");
  Console.WriteLine("1 - Adicionar item");
  Console.WriteLine("2 - Remover item");
  Console.WriteLine("3 - Listar itens");
  Console.WriteLine("4 - Sair");
  Console.Write("Escolha uma opção: ");

  string opcao = Console.ReadLine()!;

  switch (opcao)
  {
    case "1":
      AdicionarItem();
      break;
    case "2":
      RemoverItem();
      break;
    case "3":
      ListarItens();
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
