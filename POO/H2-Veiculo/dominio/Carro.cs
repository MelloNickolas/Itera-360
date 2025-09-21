public class Carro : Veiculo
{
  #region Atributos
  public int _ano;
  #endregion

  #region Propriedades
  public int Ano
  {
    get { return _ano; }
    set { _ano = value; }
  }
  #endregion

  #region Construtor
  public Carro(string marca, string modelo, int ano) : base(marca, modelo)
  {
    Ano = ano;
  }
  #endregion

  #region Metodos
  public override void MostrarDetalhes()
  {
    Console.WriteLine($"{Marca} | {Modelo} | {Ano}");
  }
  #endregion
}