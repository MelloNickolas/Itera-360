public class Conta
{
  #region Propriedades
  public string Nome { get; set; }
  public double Saldo { get; set; }
  #endregion

  #region Construtores
  public Conta(string nome, double saldo)
  {
    Nome = nome;
    Saldo = saldo;
  }
  #endregion

  public virtual void Depositar(double value)
  {
    Saldo += value;
    Console.WriteLine($"{Nome} | {Saldo}");
  }
  public virtual void Sacar(double value)
  {
    Saldo -= value;
    Console.WriteLine($"{Nome} | {Saldo}");
  }
}