class Animal
{
  #region Propriedades
  public string Nome;
  public int Idade;
  #endregion

  #region Construtores
  public Animal(string nome, int idade)
  {
    Nome = nome;
    Idade = idade;
  }
  #endregion

  #region Metodos
  public virtual void EmitirSom()
  {
    Console.WriteLine("Emitindo som...");
  }
  #endregion
}