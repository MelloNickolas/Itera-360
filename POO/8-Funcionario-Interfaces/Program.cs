var primeiroGerente = new Gerente("Nickolas", 200, "Contratado", "TI");
var primeiroFuncionario = new Funcionario("Joao", 400, "Contratado");
var funcionarioDemitido = new Funcionario("Flavio", 400, "Demitido");

Console.WriteLine($"\n{primeiroFuncionario.Nome} | {primeiroFuncionario.Matricula} | {primeiroFuncionario.Salario} | {primeiroFuncionario.Situacao}");
Console.WriteLine($"{primeiroGerente.Nome} | {primeiroGerente.Matricula} | {primeiroGerente.Salario} | {primeiroGerente.Situacao} | {primeiroGerente.Departamento}");
Console.WriteLine($"{funcionarioDemitido.Nome} | {funcionarioDemitido.Matricula} | {funcionarioDemitido.Salario} | {funcionarioDemitido.Situacao}");

primeiroFuncionario.DarAumento(0);
primeiroGerente.DarAumento(500);
funcionarioDemitido.DarAumento(10);

Console.WriteLine($"\n{primeiroFuncionario.Nome} | {primeiroFuncionario.Matricula} | {primeiroFuncionario.Salario} | {primeiroFuncionario.Situacao}");
Console.WriteLine($"{primeiroGerente.Nome} | {primeiroGerente.Matricula} | {primeiroGerente.Salario} | {primeiroGerente.Situacao} | {primeiroGerente.Departamento}");
Console.WriteLine($"{funcionarioDemitido.Nome} | {funcionarioDemitido.Matricula} | {funcionarioDemitido.Salario} | {funcionarioDemitido.Situacao}");

primeiroFuncionario.Demitir();
primeiroGerente.Demitir();

Console.WriteLine($"\n{primeiroFuncionario.Nome} | {primeiroFuncionario.Matricula} | {primeiroFuncionario.Salario} | {primeiroFuncionario.Situacao}");
Console.WriteLine($"{primeiroGerente.Nome} | {primeiroGerente.Matricula} | {primeiroGerente.Salario} | {primeiroGerente.Situacao} | {primeiroGerente.Departamento}");
