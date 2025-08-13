Console.WriteLine("Me informe um numero um numero : ");
int numero = int.Parse(Console.ReadLine()!);

Console.WriteLine($"Qual numero você acha que é multiplo de {numero} :");
int multiplo = int.Parse(Console.ReadLine()!);

if (multiplo % numero == 0)
{
  Console.WriteLine($"{multiplo} é múltiplo de {numero}");
}
else
{
  Console.WriteLine($"{multiplo} não é múltiplo de {numero}");
}