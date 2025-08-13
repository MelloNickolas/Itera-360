Console.WriteLine("Qual o raio do circulo (M)?");
double raio = double.Parse(Console.ReadLine()!);

double area = Math.PI * (raio * raio);

Console.WriteLine($"A area do circulo é de {area:F2}m");