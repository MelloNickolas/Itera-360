public class Veiculo
{
  #region atributos
  private string _placa;
  private string _modelo;
  private string _marca;
  private TipoVeiculo _tipoVeiculo;
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
  public TipoVeiculo TipoVeiculo
  {
    get { return _tipoVeiculo; }
    private set { _tipoVeiculo = value; }
  }
  #endregion

  #region Construtores
  public Veiculo(string placa)
  {
    // A placa nao pode ser nula!
    if (string.IsNullOrWhiteSpace(placa))
      throw new ArgumentException("A placa do veículo não pode ser nula ou vazia.");

    Placa = placa;
  }

  public Veiculo(string placa, string modelo, string marca, TipoVeiculo tipoVeiculo) : this(placa)
  {
    Modelo = modelo;
    Marca = marca;
    TipoVeiculo = tipoVeiculo;
  }
  #endregion

  #region Metodos
  public void AssociarTAG(Tag tag)
  {
    // Não se pode associar a uma tag nula!
    if (tag == null)
      throw new ArgumentException("A TAG não pode ser nula.");

    Tag = tag;
    Console.WriteLine($"Tag {tag.Identificacao} associada ao veículo {Placa}");
  }

  public void AlterarPlaca(string placa)
  {
    // Não da para alterar uma placa nula!
    if (string.IsNullOrWhiteSpace(placa))
      throw new ArgumentException("A nova placa não pode ser nula ou vazia.");

    Placa = placa;
    Console.WriteLine($"A placa foi alterada para {Placa}");
  }
  #endregion
}
