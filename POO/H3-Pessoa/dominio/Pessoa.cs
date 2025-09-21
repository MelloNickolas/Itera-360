public class Pessoa
{
  #region Propriedades
  public string Nome { get; set; }
  public int Idade { get; set; }
  #endregion

  #region Construtores
  public Pessoa(string nome, int idade)
  {
    Nome = nome;
    Idade = idade;
  }
  #endregion

  public virtual void Apresentar()
  {
        Console.WriteLine($"{Nome} | {Idade}");

  }
}