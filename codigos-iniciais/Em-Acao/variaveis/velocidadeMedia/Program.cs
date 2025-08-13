Console.WriteLine("Qual a distância percorrida (em quilômetros)?");
double distancia = double.Parse(Console.ReadLine()!);

Console.WriteLine("Qual o tempo gasto (em horas)?");
double tempo = double.Parse(Console.ReadLine()!);

double velocidadeMedia = distancia / tempo;

Console.WriteLine($"A velocidade média é de {velocidadeMedia} km/h");