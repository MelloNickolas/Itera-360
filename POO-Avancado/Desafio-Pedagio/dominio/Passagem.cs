public class Passagem
{
    #region Atributos
    public Veiculo Veiculo { get; private set; }
    public decimal ValorPassagem { get; private set; }
    public DateTime Data { get; private set; }
    #endregion

    #region Construtor
    public Passagem(Veiculo veiculo)
    {
        Veiculo = veiculo ?? throw new ArgumentException("Veículo não pode ser nulo.");
        Data = DateTime.Now;

        switch (veiculo.TipoVeiculo)
        {
            case TipoVeiculo.Moto:
                ValorPassagem = 1.50m;
                break;
            case TipoVeiculo.Carro:
                ValorPassagem = 2.90m;
                break;
            case TipoVeiculo.Caminhao:
                ValorPassagem = 18.90m;
                break;
            default:
                throw new ArgumentException("Tipo de veículo desconhecido.");
        }
    }
    #endregion

    #region Métodos
    public void MostrarValorPassagem()
    {
        Console.WriteLine($"Veículo {Veiculo.Placa} - Tipo: {Veiculo.TipoVeiculo} - Valor da passagem: R${ValorPassagem} - Data: {Data}");
    }
    #endregion
}
