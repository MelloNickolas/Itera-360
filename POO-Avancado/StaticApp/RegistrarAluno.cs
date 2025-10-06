public static class RegistroEscolar
{
  // Campo estático para manter a contagem de alunos registrada
  private static int contadorAlunos;

  // Propriedade estatica para permitir que outras classe consultem o contador de alunos
  public static int ContadorAlunos
  {
    get { return contadorAlunos; }
  }

  // Construtor estático
  static RegistroEscolar()
  {
    // Inicializando o contadore de alunos
    contadorAlunos = 0;
  }

  //metodo estatico para registrar um aluno
  public static void RegistrarAluno(Aluno aluno)
  {
    // Implementacao da logica de registro(salkvar em banco de dados , por ecemplo)

    // incrementar o contador de alunos
    contadorAlunos ++;
  }

}
