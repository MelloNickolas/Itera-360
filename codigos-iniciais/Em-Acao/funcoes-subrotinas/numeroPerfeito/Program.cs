Console.WriteLine("Digite um número inteiro:");
int numero = int.Parse(Console.ReadLine()!);

bool ValidarNumeroPerfeito(int n)
{
    int somaDivisores = 0;

    for (int i = 1; i < n; i++)
    {
        if (n % i == 0)
        {
            somaDivisores += i;
        }
    }

    return somaDivisores == n;
}

bool isPerfeito = ValidarNumeroPerfeito(numero);

if (isPerfeito)
{
    Console.WriteLine($"{numero} é um número perfeito.");
}
else
{
    Console.WriteLine($"{numero} não é um número perfeito.");
}
