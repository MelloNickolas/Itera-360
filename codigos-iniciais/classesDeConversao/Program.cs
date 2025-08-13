string stringComNumero = "145";

try
{
  int numeroConvertido = Convert.ToInt32(stringComNumero);

  Console.WriteLine($"Valor da string: {stringComNumero}");
  Console.WriteLine($"Valor convertido para int: {numeroConvertido}");
}
catch (FormatException)
{
  Console.WriteLine("Erro: A string não está em um formato numérico válido.");
}
catch (OverflowException)
{
  Console.WriteLine("Erro: O número é muito grande ou muito pequeno para um tipo int.");
}


string stringComCaracterEspecial = "23$";
try
{
  int tenteConverter = Convert.ToInt32(stringComCaracterEspecial);

  Console.WriteLine($"Valor da string: {stringComCaracterEspecial}");
  Console.WriteLine($"Valor convertido para int: {tenteConverter}");
}
catch (FormatException)
{
  Console.WriteLine("Erro: A string não está em um formato numérico válido.");
}
catch (OverflowException)
{
  Console.WriteLine("Erro: O número é muito grande ou muito pequeno para um tipo int.");
}