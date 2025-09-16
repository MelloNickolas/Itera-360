public class Funcionario
{
  #region Atributos
  public string Nome { get; set; }
  public int Matricula { get; set; }
  public decimal Salario { get; set; }
  #endregion

  #region Métodos
  public void DarAumento(decimal valorAumento)
  {
    Salario += valorAumento;
    Console.WriteLine($"{Nome} recebeu um aumento de R${valorAumento}. Agora o novo salário é de : R${Salario}");
  }
  #endregion

  #region Construtor
  public Funcionario(string nome, int matricula, decimal salario)
  {
    Nome = nome;
    Matricula = matricula;
    Salario = salario;
  }
  #endregion
}

