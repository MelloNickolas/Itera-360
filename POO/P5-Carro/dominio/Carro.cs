public class Carro
{
  #region Atributos
  public string _marca;
  public string _modelo;
  public int _ano;
  #endregion

  #region Propriedades
  public string Marca
  {
    get { return _marca; }
    set { _marca = value; }
  }
  public string Modelo
  {
    get { return _modelo; }
    set { _modelo = value; }
  }
  public int Ano
  {
    get { return _ano; }
    set
    {
      if (value >= 1886 && value <= 2025)
      {
        _ano = value;
      }
      else
      {
        Console.WriteLine("Coloque um ano de 1886 até 2025!");
      }
    }
  }
  #endregion
}


