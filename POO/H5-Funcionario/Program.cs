var f = new Funcionario("Nickolas", 100m);
var g = new Gerente("Pedro", 100m, "TI");

Console.WriteLine($"{f.Nome} | {f.Salario}");
Console.WriteLine($"{g.Nome} | {g.Salario} | {g.Departamento}");

f.CalcularBonus(10);
g.CalcularBonus(10);

Console.WriteLine($"{f.Nome} | {f.Salario}");
Console.WriteLine($"{g.Nome} | {g.Salario} | {g.Departamento}");