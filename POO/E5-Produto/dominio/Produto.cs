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
    private set
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
    private set
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

  #region Construtor
  public Produto(string nome, decimal preco, int quantidade)
  {
    Nome = nome;
    Preco = preco;
    Quantidade = quantidade;
  }
  #endregion

  #region Métodos
    public void MudarPreco(decimal preco)
    {
        Preco = preco;
    }

    public void MudarQuantidade(int quantidade)
    {
        Quantidade = quantidade;
    }
    #endregion
}


