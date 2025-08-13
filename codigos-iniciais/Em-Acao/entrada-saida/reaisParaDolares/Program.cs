Console.WriteLine("Quantos R$ você deseja converter ?");
decimal real = decimal.Parse(Console.ReadLine()!);

Console.WriteLine("Qual a taxa de cambio atual ?");
decimal cambio = decimal.Parse(Console.ReadLine()!);

decimal dolar = real / cambio;

Console.WriteLine($"A conversão para o Dolar é de U${dolar}");