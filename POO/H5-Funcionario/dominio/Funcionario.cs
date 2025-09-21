public class Funcionario
{
  #region Atributos
  public string _nome;
  public decimal _salario;
  #endregion

  #region Propriedades
  public string Nome
  {
    get { return _nome; }
    set { _nome = value; }
  }
  public decimal Salario
  {
    get { return _salario; }
    set { _salario = value; }
  }
  #endregion

  #region Construtor 
  public Funcionario(string nome, decimal salario)
  {
    Nome = nome;
    Salario = salario;
  }
  #endregion

  #region Metodos
  public virtual void CalcularBonus(int value)
  {
    Salario = +Salario + (Salario * value / 100);
    Console.WriteLine($"\nNovo Salaraio : {Salario}");
  }
  #endregion
}

