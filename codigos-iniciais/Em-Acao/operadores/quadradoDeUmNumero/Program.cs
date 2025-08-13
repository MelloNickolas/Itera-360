Console.WriteLine("Qual o número que voce deseja ver o quadrado ?");
double numero = double.Parse(Console.ReadLine()!);

double quadrado = Math.Pow(numero, 2);

Console.WriteLine($"O quadrado de {numero} é igual a {quadrado}");