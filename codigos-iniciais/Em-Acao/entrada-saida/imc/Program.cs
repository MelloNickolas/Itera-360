Console.WriteLine("Qual a sua altura em CM (Centímetros): ");
int altura = int.Parse(Console.ReadLine());

Console.WriteLine("Qual o seu peso em KG (Quilogramas): ");
double peso = double.Parse(Console.ReadLine());

double alturaM = altura / 100.0;
double imc = peso / (alturaM * alturaM);

Console.WriteLine($"Seu IMC é de: {imc:F2}");
