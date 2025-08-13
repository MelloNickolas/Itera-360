Console.WriteLine("Digite a temperatura em Celsius:");
double celsius = double.Parse(Console.ReadLine()!);

double CelsiusParaFahrenheit(double c)
{
  return (c * 9 / 5) + 32;
}

double fahrenheit = CelsiusParaFahrenheit(celsius);
Console.WriteLine($"A temperatura em Fahrenheit é: {fahrenheit:F2}");
