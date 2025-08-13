Console.WriteLine("Digite o raio do círculo:");
double raio = double.Parse(Console.ReadLine()!);

double CalcularAreaCirculo(double r)
{
    return Math.PI * Math.Pow(raio, 2);
}

double area = CalcularAreaCirculo(raio);
Console.WriteLine($"A área do círculo é: {area:F2}");
