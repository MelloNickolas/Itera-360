string[] fila = new string[10];
int inicioFila = 0;
int fimFila = -1;
string cliente = "";

void Enfilerar(string cliente)
{
  if (fimFila < 9)
  {
    fimFila++;
    fila[fimFila] = cliente;
    Console.WriteLine($"- {cliente} entrou na fila! ");
  }
  else
  {
    Console.WriteLine("----- A FILA ESTÁ LOTADA -----\n");
  }
}

void Desinfilerar()
{
  if (inicioFila <= fimFila)
  {
    Console.WriteLine($"- {fila[inicioFila]} foi atendido e se retirou da fila!");
    inicioFila++;
  }
  else
  {
    Console.WriteLine("----- A FILA ESTÁ VAZIA -----\n");
  }
}

void estadoAtualFila()
{
  if (inicioFila <= fimFila)
  {
    Console.WriteLine($"- O próximo a ser atendido é : {fila[inicioFila]}");
    Console.Write("A fila está na seguinte ordem: ");
    for (int i = inicioFila; i <= fimFila; i++)
    {
      Console.Write(fila[i]);
      if (i < fimFila)
        Console.Write(", ");
    }
    Console.WriteLine();
  }
  else
  {
    Console.WriteLine("A fila está vazia.");
  }
}

int opcao = 0;
do
{
  Console.WriteLine("\n------------------------------------");
  Console.WriteLine("1 - Adicionar novos clientes! ");
  Console.WriteLine("2 - Atender cliente! ");
  Console.WriteLine("3 - Exibir estado atual da fila! ");
  Console.WriteLine("0 - Encerrar programa");
  Console.WriteLine("------------------------------------");
  Console.WriteLine("- O que você deseja fazer agora ? ");
  opcao = int.Parse(Console.ReadLine()!);

  switch (opcao)
  {
    case 1:
      Console.WriteLine("- Qual o nome do cliente?");
      cliente = Console.ReadLine()!;
      Enfilerar(cliente);
      break;

    case 2:
      Desinfilerar();
      break;

    case 3:
      estadoAtualFila();
      break;

    case 0:
      Console.WriteLine("\nEncerrando programa...");
      break;

    default:
      Console.WriteLine("----- OPÇÃO INVÁLIDA -----\n");
      break;
  }
} while (opcao != 0);