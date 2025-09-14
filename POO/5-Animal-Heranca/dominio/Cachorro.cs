class Cachorro : Animal
{
  #region Propriedades
  public string Raca;
  #endregion

  #region Construtores
  public Cachorro(string especie, string habitat, string raca) : base(especie, habitat)
  {
    Raca = raca;
  }
  #endregion
}