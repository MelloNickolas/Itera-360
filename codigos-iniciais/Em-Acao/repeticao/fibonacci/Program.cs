Console.WriteLine("Digite o número de termos da sequência de Fibonacci:");
int N = int.Parse(Console.ReadLine()!);

int a = 0, b = 1;

Console.WriteLine("Sequência de Fibonacci:");

for (int i = 1; i <= N; i++)
{
    Console.WriteLine(a);
    int proximo = a + b;
    a = b;
    b = proximo;
}
