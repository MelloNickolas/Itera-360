class ProdutoImportado : Produto
{
  #region Propriedades
  public string PaisOrigem;
  #endregion

  #region Construtores
  public ProdutoImportado(string nome, decimal preco, string categoria, string paisOrigem) : base(nome, preco, categoria)
  {
    PaisOrigem = paisOrigem;
  }
  #endregion
}