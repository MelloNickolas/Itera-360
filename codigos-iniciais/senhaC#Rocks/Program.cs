string senha = "";

while (senha != "C#Rocks")
{
  Console.WriteLine("\nQual a sua senha ?");
  senha = Console.ReadLine()!;

  if (senha != "C#Rocks")
  {
    Console.WriteLine("SENHA ERRADA");
  }
}
Console.WriteLine("PROGRAMA FINALIZADO");