Console.WriteLine("Digite um número inteiro N:");
int N = int.Parse(Console.ReadLine()!);

int soma = 0;

for (int i = 1; i <= N; i++)
{
  soma += i;
}
Console.WriteLine($"A soma de todos os números de 1 a {N} é: {soma}");
