public class Veiculo
{
  #region atributos
  private string _placa;
  private string _modelo;
  private string _marca;
  private Tag _tag;
  #endregion
  #region propriedades
  public string Placa
  {
    get { return _placa; }
    private set { _placa = value; }
  }
  public string Modelo
  {
    get { return _modelo; }
    set { _modelo = value; }
  }
  public string Marca
  {
    get { return _marca; }
    set { _marca = value; }
  }
  public Tag Tag
  {
    get { return _tag; }
    private set { _tag = value; }
  }
  #endregion

  #region Construtores
  public Veiculo(string placa)
  {
    Placa = placa;
  }
  public Veiculo(string placa, string modelo, string marca) : this(placa)
  {
    Modelo = modelo;
    Marca = marca;
  }
  #endregion

  #region Metodos
  public void AssociarTAG(Tag tag)
  {
    Tag = tag;
    Console.WriteLine($"Tag {tag.Identificacao} associada ao veículo {Placa}");
  }
  public void AlterarPlaca(string placa)
  {
    Placa = placa;
    Console.WriteLine($"A placa foi alterada para {Placa}");
  }
  #endregion
}