public class Designer : Funcionario
{
  public decimal Bonus { get; set; }

  public Designer(string nome, decimal salarioBase, decimal bonus) : base(nome, salarioBase)
  {
    Bonus = bonus;
  }

  public override decimal CalcularSalario()
  {
    return SalarioBase + Bonus;
  }
}
