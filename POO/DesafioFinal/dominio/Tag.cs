public class Tag
{
  #region atributos
  private int _identificacao;
  private decimal _saldo;
  #endregion

  #region propriedades
  public int Identificacao
  {
    get { return _identificacao; }
    private set { _identificacao = value; }
  }
  public decimal Saldo
  {
    get { return _saldo; }
    private set { _saldo = value; }
  }
  #endregion

  #region Construtores
  public Tag(int identificacao)
  {
    Saldo = 0;
    Identificacao = identificacao;
  }
  #endregion

  #region Metodos
  public void RecarregarSaldo(decimal value)
  {
    Saldo += value;
    Console.WriteLine($"O novo saldo é de R${Saldo}");
  }
  public void ObterSaldo()
  {
    Console.WriteLine($"O seu saldo é de R${Saldo}");
  }
  public void DescontarSaldo(decimal value)
  {
    Saldo -= value;
    Console.WriteLine($"O novo saldo é de R${Saldo}");
  }
  #endregion
}