var primeiraPessoa = new Pessoa("Nickolas");
var segundaPessoa = new Pessoa("Pedro", 18);
var terceiraPessoa = new Pessoa("João", 13, "Argentino");

Console.Write($"\n{primeiraPessoa.Nome} | {primeiraPessoa.Idade} | {primeiraPessoa.Nacionalidade}");
Console.Write($"\n{segundaPessoa.Nome} | {segundaPessoa.Idade} | {segundaPessoa.Nacionalidade}");
Console.Write($"\n{terceiraPessoa.Nome} | {terceiraPessoa.Idade} | {terceiraPessoa.Nacionalidade}");