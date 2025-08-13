
Console.Write("Digite a média do aluno (ou pressione Enter para não informar): ");
string? entrada = Console.ReadLine();

double? media = null;

if (!string.IsNullOrWhiteSpace(entrada))
{
  media = double.Parse(entrada);
}

if (media == null)
{
  Console.WriteLine("Média não informada!");
}
else
{
  Console.WriteLine("A média do aluno é: " + media);
}
