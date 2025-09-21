class Cachorro : Animal
{
  #region Construtor
  public Cachorro(string nome, int idade) : base(nome, idade)
  {
  }
  #endregion

  #region Metodos
  public override void EmitirSom()
  {
    Console.WriteLine("AU AU AU");
  }
  #endregion
}