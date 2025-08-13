Console.WriteLine("Digite um número:");
int N = int.Parse(Console.ReadLine()!);

Console.WriteLine("Números pares de 1 a " + N + ":");

for (int i = 2; i <= N; i += 2)
{
  Console.WriteLine(i);
}
