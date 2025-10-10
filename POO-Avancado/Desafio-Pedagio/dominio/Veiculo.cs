public class Veiculo
{
    #region Atributos
    private string _placa;
    private string _modelo;
    private string _marca;
    private TipoVeiculo _tipoVeiculo;
    private Tag _tag;
    #endregion

    #region Propriedades
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
    public TipoVeiculo TipoVeiculo => _tipoVeiculo;
    #endregion

    #region Construtores
    public Veiculo(string placa, string modelo, string marca, TipoVeiculo tipoVeiculo)
    {
        if (string.IsNullOrWhiteSpace(placa))
            throw new ArgumentException("A placa do veículo não pode ser nula ou vazia.");

        _placa = placa;
        _modelo = modelo;
        _marca = marca;
        _tipoVeiculo = tipoVeiculo;
    }
    #endregion

    #region Métodos
    public void AssociarTAG(Tag tag)
    {
        if (tag == null)
            throw new ArgumentException("A TAG não pode ser nula.");

        _tag = tag;
        Console.WriteLine($"Tag {tag.Identificacao} associada ao veículo {Placa}");
    }

    public void AlterarPlaca(string placa)
    {
        if (string.IsNullOrWhiteSpace(placa))
            throw new ArgumentException("A nova placa não pode ser nula ou vazia.");

        _placa = placa;
        Console.WriteLine($"A placa foi alterada para {Placa}");
    }
    #endregion
}
