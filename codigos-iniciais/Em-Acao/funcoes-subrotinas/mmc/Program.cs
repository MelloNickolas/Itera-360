Console.WriteLine("Digite o primeiro número:");
int num1 = int.Parse(Console.ReadLine()!);

Console.WriteLine("Digite o segundo número:");
int num2 = int.Parse(Console.ReadLine()!);

int CalcularMinimoMultiploComum(int a, int b)
{
  int maior = a > b ? a : b;
  int mmc = maior;

  while (mmc % a != 0 || mmc % b != 0)
  {
    mmc += maior;
  }

  return mmc;
}

int mmcResultado = CalcularMinimoMultiploComum(num1, num2);
Console.WriteLine($"O Mínimo Múltiplo Comum (MMC) de {num1} e {num2} é: {mmcResultado}");
