
Console.Write("Insira um número inteiro: ");
int numeroInteiro = int.Parse(Console.ReadLine()!);

Console.Write("Insira um número com casas decimais: ");
float numeroDecimal = float.Parse(Console.ReadLine()!);

Console.Write("Insira um caractere: ");
char caractere = char.Parse(Console.ReadLine()!);

Console.Write("Insira um valor booleano (true/false): ");
bool valorBooleano = bool.Parse(Console.ReadLine()!);

Console.WriteLine("\nVocê inseriu:");
Console.WriteLine("Número inteiro : " + numeroInteiro);
Console.WriteLine("Número decimal : " + numeroDecimal);
Console.WriteLine("Caractere : " + caractere);
Console.WriteLine("Valor booleano : " + valorBooleano);