double calcularFrete(int opcaoRegiao)
{
  double frete = 0;

  switch (opcaoRegiao)
  {
    case 1:
      frete = 20;
      break;
    case 2:
      frete = 30;
      break;
    case 3:
      frete = 25;
      break;
    case 4:
      frete = 20;
      break;
    case 5:
      frete = 40;
      break;
    default:
      Console.WriteLine("Opcao inválida!");
      break;
  }

  return frete;
}


Console.WriteLine("Qual o nome do cliente ? ");
string nomeCliente = Console.ReadLine()!;

Console.WriteLine($"Qual o produto do/da {nomeCliente} ? ");
string produtoCliente = Console.ReadLine()!;

Console.WriteLine("\nTABELA REGIÃO ");
Console.WriteLine("1 - Sudeste");
Console.WriteLine("2 - Nordeste");
Console.WriteLine("3 - Centro-Oeste");
Console.WriteLine("4 - Sul");
Console.WriteLine("5 - Norte");

Console.WriteLine($"\nEm qual região o/a {nomeCliente} mora? (Coloque o número da região!)");
int opcaoRegiao = int.Parse(Console.ReadLine()!);

double frete = calcularFrete(opcaoRegiao);

Console.WriteLine($"O valor do frete é de R${frete}");