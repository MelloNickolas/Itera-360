double saldo = 0.0;
const double valorPedagio = 2.90;

void CarregarTag(double valor)
{
  if (valor > 0)
  {
    saldo += valor;
  }
  else
  {
    Console.WriteLine("Valor inválido para carregar.");
  }
}

void ExibirSaldo()
{
  Console.WriteLine($"Saldo atual da TAG: R$ {saldo:F2}");
}

void PassarPedagio()
{
  if (saldo >= valorPedagio)
  {
    saldo -= valorPedagio;
    Console.WriteLine("Cancela aberta. Pode passar.");
    Console.WriteLine($"Pedágio pago. Saldo atual: R$ {saldo:F2}");
  }
  else
  {
    Console.WriteLine("Cancela permanecerá fechada.");
    Console.WriteLine("Saldo insuficiente para pagar o pedágio.");
  }
}

int opcao;
do
{
  Console.WriteLine("===============================================");
  Console.WriteLine("Escolha uma das opções abaixo:");
  Console.WriteLine("1 - Carregar TAG");
  Console.WriteLine("2 - Exibir Saldo");
  Console.WriteLine("3 - Passar no Pedágio");
  Console.WriteLine("0 - Sair");
  Console.WriteLine("===============================================");
  Console.Write("Opção: ");

  string entrada = Console.ReadLine();

  if (!int.TryParse(entrada, out opcao))
  {
    Console.WriteLine("Entrada inválida. Tente novamente.");
    continue;
  }

  Console.WriteLine(); // Linha em branco

  switch (opcao)
  {
    case 1:
      Console.Write("Informe o valor para carregar na TAG: ");
      if (double.TryParse(Console.ReadLine(), out double valor))
      {
        CarregarTag(valor);
      }
      else
      {
        Console.WriteLine("Valor inválido.");
      }
      break;

    case 2:
      ExibirSaldo();
      break;

    case 3:
      PassarPedagio();
      break;

    case 0:
      Console.WriteLine("Encerrando o sistema...");
      break;

    default:
      Console.WriteLine("Opção inválida. Tente novamente.");
      break;
  }

} while (opcao != 0);
