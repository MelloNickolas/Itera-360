public class Gerente : Funcionario
{

  #region Propriedades
  public string Departamento { get; set; }
  #endregion

  #region Construtor 
  public Gerente(string nome, decimal salario, string departamento) : base(nome, salario)
  {
    Departamento = departamento;
  }
  #endregion

  #region Metodos
  public override void CalcularBonus(int value)
  {
    Salario += value * 2 * Salario / 100;
    Console.WriteLine($"\nNovo Salaraio, com bonus dobrado : {Salario}");
  }
  #endregion
}

