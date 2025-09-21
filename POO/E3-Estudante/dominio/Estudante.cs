public class Estudante
{
  private double _nota; //a auto-proprieda nao permite colocar validacao direta

  #region Propriedades
  public string Nome { get; set; }
  public double Nota
  {
    get { return _nota; }
    set
    {
      if (value < 0)
      {
        _nota = 0;
        Console.WriteLine("Coloque uma nota válida!, por enquando ela será 0");
      }
      else if (value > 100)
      {
        _nota = 100;
        Console.WriteLine("Coloque uma nota válida!, por enquando ela será 0");
      }
      else
      {
        _nota = value;
      }
    }
  }
  #endregion

  #region Construtores
  public Estudante(string nome, double nota)
  {
    Nome = nome;
    Nota = nota;
  }
  #endregion
}

