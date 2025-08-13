Console.WriteLine("Qual número voce deseja saber a tabuada ? ");
int numero = int.Parse(Console.ReadLine()!);

Console.WriteLine($"Tabuada do {numero}:");
Console.WriteLine("------------------------");

for (int i = 1; i <= 10; i++)
{
  Console.WriteLine($"{numero} x {i} = {numero * i}");
}

Console.WriteLine("------------------------");