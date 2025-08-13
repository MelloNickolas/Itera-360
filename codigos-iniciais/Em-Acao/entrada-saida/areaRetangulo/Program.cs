Console.WriteLine("Qual a ALTURA do retangulo (M)? ");
double altura = double.Parse(Console.ReadLine()!);

Console.WriteLine("Qual a LARGURA do retangulo (M)?");
double largura = double.Parse(Console.ReadLine()!);

double area = altura * largura;

Console.WriteLine($"A area do retangulo é de : {area}m");