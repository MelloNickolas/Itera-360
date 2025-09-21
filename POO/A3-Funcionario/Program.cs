var dev = new Programador("Nick", 3000m, 10, 50m);
var designer = new Designer("Ana", 2800m, 400m);

Console.WriteLine($"{dev.Nome} - Salário: R$ {dev.CalcularSalario()}");
Console.WriteLine($"{designer.Nome} - Salário: R$ {designer.CalcularSalario()}");