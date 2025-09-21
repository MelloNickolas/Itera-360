Conta poupanca = new ContaPoupanca(1000m);
Conta investimento = new ContaInvestimento(1000m);

Console.WriteLine($"Juros da Poupança: R$ {poupanca.CalcularJuros()}");
Console.WriteLine($"Juros do Investimento: R$ {investimento.CalcularJuros()}");