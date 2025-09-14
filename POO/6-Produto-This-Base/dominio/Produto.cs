class Produto
{
  #region Propriedades
  public string Nome;
  public decimal Preco;
  public string Categoria;
  #endregion

  #region Construtores
  public Produto(string nome)
  {
    Nome = nome;
  }
  public Produto(string nome, decimal preco) : this(nome)
  {
    Preco = preco;
  }
  public Produto(string nome, decimal preco, string categoria) : this(nome, preco)
  {
    Categoria = categoria;
  }
  #endregion
}