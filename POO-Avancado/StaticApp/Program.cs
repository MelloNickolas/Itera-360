
var aluno1 = new Aluno("Maria", 20);
var aluno2 = new Aluno("João", 22);

RegistroEscolar.RegistrarAluno(aluno1);
RegistroEscolar.RegistrarAluno(aluno2);

Console.WriteLine($"Total de alunos registrados -- {RegistroEscolar.ContadorAlunos}");