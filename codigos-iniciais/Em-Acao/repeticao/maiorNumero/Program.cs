int maior = int.MinValue;

for (int i = 1; i <= 10; i++)
{
    Console.WriteLine($"Digite o {i}º número:");
    int numero = int.Parse(Console.ReadLine()!);

    if (numero > maior)
    {
        maior = numero;
    }
}

Console.WriteLine($"O maior número digitado foi: {maior}");