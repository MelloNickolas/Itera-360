public class TentativaPassagem : Passagem
{
  #region Atributos
  private string _msgFalha;
  #endregion

  #region Propriedades
  public string MsgFalha => _msgFalha;
  #endregion

  #region Construtor
  public TentativaPassagem(Veiculo veiculo, string msgFalha) : base(veiculo)
  {
    _msgFalha = msgFalha;
  }
  #endregion

  #region Métodos
  public void MostrarTentativa()
  {
    Console.WriteLine($"Veículo {Veiculo.Placa} - Tipo: {Veiculo.TipoVeiculo} - {MsgFalha} - Data: {Data}");
  }
  #endregion
}
