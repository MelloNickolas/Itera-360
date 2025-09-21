
public abstract class Funcionario
{
  public string Nome { get; set; }
  public decimal SalarioBase { get; set; }

  public Funcionario(string nome, decimal salarioBase)
  {
    Nome = nome;
    SalarioBase = salarioBase;
  }

  public abstract decimal CalcularSalario();
}