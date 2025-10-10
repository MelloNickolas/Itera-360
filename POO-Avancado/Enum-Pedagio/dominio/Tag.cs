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
    // O número da tag tem que ser POSITIVO!
    if (identificacao <= 0)
      throw new ArgumentException("A identificação da TAG deve ser um número positivo.");

    Saldo = 0;
    Identificacao = identificacao;
  }
  #endregion

  #region Metodos
  public void RecarregarSaldo(decimal value)
  {
    // Não pode recarregar um número negativo!
    if (value <= 0)
      throw new ArgumentException("O valor de recarga deve ser maior que zero.");

    Saldo += value;
    Console.WriteLine($"O novo saldo é de R${Saldo}");
  }

  public void ObterSaldo()
  {
    Console.WriteLine($"O seu saldo é de R${Saldo}");
  }

  public void DescontarSaldo(decimal value)
  {
    // Não da pra descontar e no fim acabar ganhando né???
    if (value <= 0)
      throw new ArgumentException("O valor do desconto deve ser maior que zero.");

    // Invalida a operação se o valor do saldo for insuficiente
    if (Saldo < value)
      throw new InvalidOperationException("Saldo insuficiente para realizar o desconto.");

    Saldo -= value;
    Console.WriteLine($"O novo saldo é de R${Saldo}");
  }
  #endregion
}
