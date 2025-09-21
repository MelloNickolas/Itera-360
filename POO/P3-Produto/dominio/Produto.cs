public class Produto
{
  #region Atributos
  public string _nome;
  public decimal _preco;
  public int _quantidade;
  #endregion

  #region Propriedades
  public string Nome
  {
    get { return _nome; }
    set { _nome = value; }
  }
  public decimal Preco
  {
    get { return _preco; }
    set
    {
      if (value < 0)
      {
        Console.WriteLine($"O preço não pode ser negativo!");
        _preco = 0;
      }
      else
      {
        _preco = value;
      }
    }
  }
  public int Quantidade
  {
    get { return _quantidade; }
    set
    {
      if (value < 0)
      {
        Console.WriteLine($"A quantidade não pode ser negativa!");
        _quantidade = 0;
      }
      else
      {
        _quantidade = value;
      }
    }
  }

  #endregion
}


