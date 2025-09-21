public class ContaBancaria
{
  #region Propriedades
  public int NumeroConta { get; set; }
  public string Titular { get; set; }
  public decimal Saldo { get; private set; }

  #endregion

  #region Construtores
  public ContaBancaria(int numeroConta, string titular)
  {
    NumeroConta = numeroConta;
    Titular = titular;
    Saldo = 0m;
  }
  #endregion

  #region Metodos 
  public void Deposito(decimal value)
  {
    Saldo += value;
  }
  public void Saque(decimal value)
  {
    Saldo -= value;
  }
  #endregion
}


