var primeiraConta = new ContaBancaria(1097, "Nickolas");

Console.WriteLine($"{primeiraConta.NumeroConta} | {primeiraConta.Titular} | {primeiraConta.Saldo}");

primeiraConta.Deposito(100m);

Console.WriteLine($"{primeiraConta.NumeroConta} | {primeiraConta.Titular} | {primeiraConta.Saldo}");

primeiraConta.Saque(10m);

Console.WriteLine($"{primeiraConta.NumeroConta} | {primeiraConta.Titular} | {primeiraConta.Saldo}");