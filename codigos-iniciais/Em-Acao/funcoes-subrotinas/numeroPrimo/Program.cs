Console.WriteLine("Digite um número inteiro:");
int numero = int.Parse(Console.ReadLine()!);

bool ValidarNumeroPrimo(int n)
{
  if (n <= 1) return false;

  for (int i = 2; i <= Math.Sqrt(n); i++)
  {
    if (n % i == 0)
    {
      return false;
    }
  }
  return true;
}

bool isPrimo = ValidarNumeroPrimo(numero);

if (isPrimo)
{
  Console.WriteLine($"{numero} é um número primo.");
}
else
{
  Console.WriteLine($"{numero} não é um número primo.");
}
