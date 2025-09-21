public class Aluno : Pessoa
{
  #region Propriedade
  public int Matricula { get; set; }
  #endregion

  #region Construtores
  public Aluno(string nome, int idade, int matricula) : base(nome, idade)
  {
    Matricula = matricula;
  }
  #endregion

  #region Metodos
  public override void Apresentar()
  {
    Console.WriteLine($"{Nome} | {Idade} | {Matricula}");
  }
  #endregion
}