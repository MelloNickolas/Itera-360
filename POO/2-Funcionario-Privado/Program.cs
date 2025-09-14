var primerioFuncionario = new Funcionario("NIckolas",3000m);
var segundoFuncionario = new Funcionario("Felipe", 3200m);

Console.WriteLine($"Funcionário: {primerioFuncionario.Nome} | Matrícula: {primerioFuncionario.Matricula} | Salário: {primerioFuncionario.Salario:C}");
Console.WriteLine($"Funcionário: {segundoFuncionario.Nome} | Matrícula: {segundoFuncionario.Matricula} | Salário: {segundoFuncionario.Salario:C}\n");


primerioFuncionario.DarAumento(500m);
segundoFuncionario.DarAumento(1000m);
primerioFuncionario.ExibirNomeSalario();
segundoFuncionario.ExibirNomeSalario();

Console.WriteLine($"\nFuncionário: {primerioFuncionario.Nome} | Matrícula: {primerioFuncionario.Matricula} | Salário: {primerioFuncionario.Salario:C}");
Console.WriteLine($"Funcionário: {segundoFuncionario.Nome} | Matrícula: {segundoFuncionario.Matricula} | Salário: {segundoFuncionario.Salario:C}");

