Console.WriteLine("Qual a altura do triangulo (M)?");
double altura = double.Parse(Console.ReadLine()!);

Console.WriteLine("Qual a base do triangulo (M)?");
double baseT = double.Parse(Console.ReadLine()!);

double area = baseT * altura / 2;

Console.WriteLine($"A area do triangulo é de {area}m");