public class Livro
{
  #region Atributos
  public string _titulo;
  public string _autor;
  public int _numeroPaginas;
  #endregion

  #region Propriedades
  public string Titulo
  {
    get { return _titulo; }
    set
    {
      if (string.IsNullOrWhiteSpace(value)) //verifica se o valor inserido de string é null ou um espaço em branco
      {
        throw new ArgumentException("O título não pode ser nulo ou vazio."); //Caso o sor vazio ele interrompe o programa na hora e avisa que está errado!
      }
      else
      {
        _titulo = value;
      }
    }
  }
  public string Autor
  {
    get { return _autor; }
    set
    {
      if (string.IsNullOrWhiteSpace(value)) //verifica se o valor inserido de string é null ou um espaço em branco
      {
        throw new ArgumentException("O livro tem que ter um autor! "); //Caso o sor vazio ele interrompe o programa na hora e avisa que está errado!
      }
      else
      {
        _autor = value;
      }
    }
  }
  public int NumeroPaginas
  {
    get { return _numeroPaginas; }
    set { _numeroPaginas = value; }
  }

  #endregion
}


