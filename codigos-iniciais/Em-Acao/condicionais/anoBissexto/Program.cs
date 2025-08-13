Console.WriteLine("Digite um ano:");
int ano = int.Parse(Console.ReadLine()!);

if (ano % 4 == 0)
{
  Console.WriteLine($"{ano} é um ano bissexto.");
}
else
{
  Console.WriteLine($"{ano} NÃO é um ano bissexto.");
}