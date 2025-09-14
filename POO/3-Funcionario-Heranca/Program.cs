var primerioFuncionario = new Funcionario("Nickolas",3000m);
var segundoFuncionario = new Funcionario("Felipe", 3200m);

Console.WriteLine($"Funcionário: {primerioFuncionario.Nome} | Matrícula: {primerioFuncionario.Matricula} | Salário: {primerioFuncionario.Salario:C}");
Console.WriteLine($"Funcionário: {segundoFuncionario.Nome} | Matrícula: {segundoFuncionario.Matricula} | Salário: {segundoFuncionario.Salario:C}\n");

primerioFuncionario.DarAumento(500m);
segundoFuncionario.DarAumento(1000m);
primerioFuncionario.ExibirNomeSalario();
segundoFuncionario.ExibirNomeSalario();

Console.WriteLine($"\nFuncionário: {primerioFuncionario.Nome} | Matrícula: {primerioFuncionario.Matricula} | Salário: {primerioFuncionario.Salario:C}");
Console.WriteLine($"Funcionário: {segundoFuncionario.Nome} | Matrícula: {segundoFuncionario.Matricula} | Salário: {segundoFuncionario.Salario:C}");

var primeiroGerente = new Gerente("Flaviane", 10000m, "TI");
var segundoGerente = new Gerente("Cadu", 7000m, "Mecânico");

primeiroGerente.ExibirGerente();
segundoGerente.ExibirGerente();

primeiroGerente.PromoverSubordinado(primerioFuncionario);
segundoGerente.PromoverSubordinado(segundoFuncionario);
