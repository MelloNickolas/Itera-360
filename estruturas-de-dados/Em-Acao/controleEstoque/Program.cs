string[] produtos = new string[10];
int[] quantidades = new int[10];
int quantidadeProdutos = 0;

void AdicionarProduto()
{
  if (quantidadeProdutos >= produtos.Length)
  {
    Console.WriteLine("--- O ESTOQUE ESTÁ CHEIO ---\n");
    return;
  }

  Console.Write("--- Nome do produto: ");
  string nome = Console.ReadLine()!;
  Console.Write("--- Quantidade: ");
  int quantidade = int.Parse(Console.ReadLine()!);

  // se tiver o produto ele só adiciona na quantidade
  for (int i = 0; i < quantidadeProdutos; i++)
  {
    if (produtos[i].Equals(nome, StringComparison.OrdinalIgnoreCase))
    {
      quantidades[i] += quantidade;
      Console.WriteLine($"--- Quantidade atualizada. Produto {nome} agora tem {quantidades[i]} unidades ---\n");
      return;
    }
  }

  produtos[quantidadeProdutos] = nome;
  quantidades[quantidadeProdutos] = quantidade;
  quantidadeProdutos++;
  Console.WriteLine("--- Produto adicionado com sucesso! ---\n");
}

void RemoverProduto()
{
  if (quantidadeProdutos == 0)
  {
    Console.WriteLine("--- NÃO EXISTEM PRODUTOS NO ESTOQUE ---\n");
    return;
  }

  Console.WriteLine("--- PRODUTOS NO ESTOQUE ---");
  for (int i = 0; i < quantidadeProdutos; i++)
  {
    Console.WriteLine($"-{i + 1}- {produtos[i]} - Quantidade: {quantidades[i]}");
  }

  Console.Write("--- Digite o nome do produto para remover: ");
  string nomeParaRemover = Console.ReadLine()!;
  int indiceParaRemover = -1;

  for (int i = 0; i < quantidadeProdutos; i++)
  {
    if (produtos[i].Equals(nomeParaRemover, StringComparison.OrdinalIgnoreCase))
    {
      indiceParaRemover = i;
      break;
    }
  }

  if (indiceParaRemover == -1)
  {
    Console.WriteLine("--- PRODUTO NÃO ENCONTRADO ---\n");
    return;
  }

  for (int i = indiceParaRemover; i < quantidadeProdutos - 1; i++)
  {
    produtos[i] = produtos[i + 1];
    quantidades[i] = quantidades[i + 1];
  }

  quantidadeProdutos--;
  Console.WriteLine($"--- Produto {nomeParaRemover} removido com sucesso! ---\n");
}

void ListarProdutos()
{
  if (quantidadeProdutos == 0)
  {
    Console.WriteLine("--- ESTOQUE VAZIO ---\n");
    return;
  }

  Console.WriteLine("--- LISTA DE PRODUTOS ---");
  for (int i = 0; i < quantidadeProdutos; i++)
  {
    Console.WriteLine($"[{i + 1}] {produtos[i]} - Quantidade: {quantidades[i]}");
  }
  Console.WriteLine();
}

bool encerrar = false;

while (!encerrar)
{
  Console.WriteLine("\n--- GERENCIADOR DE ESTOQUE ---");
  Console.WriteLine("1 - Adicionar produto");
  Console.WriteLine("2 - Remover produto");
  Console.WriteLine("3 - Listar produtos");
  Console.WriteLine("4 - Sair");
  Console.Write("Escolha uma opção: ");

  string opcao = Console.ReadLine()!;

  switch (opcao)
  {
    case "1":
      AdicionarProduto();
      break;
    case "2":
      RemoverProduto();
      break;
    case "3":
      ListarProdutos();
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