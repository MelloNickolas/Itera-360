public class ContaCorrente : Conta
{
   #region Propriedades
  public double Limite { get; set; }
  #endregion

  #region Construtores
  public ContaCorrente(string nome, double saldo, double limite) : base(nome, saldo)
  {
    Limite = limite;
  }
  #endregion

  public override void Sacar(double value)
  {
    if (value <= Limite)
    {
      Saldo -= value;
      Console.WriteLine($"{Nome} | {Saldo}");
    }
    else
    {
      Console.WriteLine("O limite foi ultrapassado! Operação cancelada");
    }
  }
}