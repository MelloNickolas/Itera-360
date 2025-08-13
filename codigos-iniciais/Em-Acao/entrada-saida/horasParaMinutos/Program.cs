Console.WriteLine("Quantas horas voce deseja converter para minutos ?");
int horas = int.Parse(Console.ReadLine()!);

int minutos = horas * 60;

Console.WriteLine($"As horas convertidas para minutos são {minutos}");