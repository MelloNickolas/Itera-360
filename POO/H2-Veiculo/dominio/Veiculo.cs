public class Veiculo
{
  #region Propriedades
  public string Marca { get; set; }
  public string Modelo { get; set; }
  #endregion

  #region Construtores
  public Veiculo(string marca, string modelo)
  {
    Marca = marca;
    Modelo = modelo;
  }
  #endregion

  #region Metodos
  public virtual void MostrarDetalhes()
  {
    Console.WriteLine($"{Marca} | {Modelo}");
  }
  #endregion
}