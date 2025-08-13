Console.WriteLine("Quantos minutos voc6e deseja converter para horas ?");
int minutos = int.Parse(Console.ReadLine()!);

int horas = minutos / 60;
int minutosRestantes = minutos % 60;

Console.WriteLine($"Os minutos convertidos para horas são {horas}h{minutosRestantes}m");