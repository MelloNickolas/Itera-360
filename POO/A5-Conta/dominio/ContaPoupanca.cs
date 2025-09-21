public class ContaPoupanca : Conta
{
  public ContaPoupanca(decimal saldo) : base(saldo) { }

  public override decimal CalcularJuros()
  {
    return Saldo * 0.005m;
  }
}