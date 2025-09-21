var c = new Conta("NIckolas", 100);
var cc = new ContaCorrente("Pedro", 200, 20);

Console.WriteLine($"{c.Nome} | {c.Saldo}");
Console.WriteLine($"{cc.Nome} | {cc.Saldo} | {cc.Limite}");

c.Sacar(80);
cc.Sacar(20);

Console.WriteLine($"{c.Nome} | {c.Saldo}");
Console.WriteLine($"{cc.Nome} | {cc.Saldo} | {cc.Limite}");

cc.Sacar(40);