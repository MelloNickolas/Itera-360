Console.WriteLine("Digite a nota do aluno (0 a 100):");
double nota = double.Parse(Console.ReadLine()!);

if (nota >= 90)
{
  Console.WriteLine("Classificação: A");
}
else if (nota >= 80)
{
  Console.WriteLine("Classificação: B");
}
else if (nota >= 70)
{
  Console.WriteLine("Classificação: C");
}
else if (nota >= 60)
{
  Console.WriteLine("Classificação: D");
}
else
{
  Console.WriteLine("Classificação: F");
}