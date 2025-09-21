public class ContaBancaria
{
  #region Propriedades
  public int NumeroConta { get; set; }
  public string Titular { get; set; }
  public decimal Saldo { get; set; }

  #endregion

  #region Construtores
  public ContaBancaria(int numeroConta, string titular)
  {
    NumeroConta = numeroConta;
    Titular = titular;
    Saldo = 0m;
  }
  #endregion
}


