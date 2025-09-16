public class Funcionario : IFuncionario
{
  #region Propriedades
  public string Nome { get; set; }
  public int Matricula { get; protected set; }
  public decimal Salario { get; protected set; } // protected ela deixa o encapsulamento para as classses bases e classes filhas
  public string Situacao { get; protected set; }
  #endregion

  #region Construtores
  public Funcionario(string nome)
  {
    Nome = nome;
    Random matriculaAleatoria = new Random();
    this.Matricula = matriculaAleatoria.Next(1, 1000);
  }
  public Funcionario(string nome, decimal salario) : this(nome)
  {
    Salario = salario;
  }
  public Funcionario(string nome, decimal salario, string situacao) : this(nome, salario)
  {
    Situacao = situacao;
  }
  #endregion

  #region Metodos
  public virtual void DarAumento(decimal valor)
  {
    if (Situacao == "Contratado")
    {
      Salario += Salario * 0.1m;
      Salario += valor;
    }
    else
    {
      Console.WriteLine("A pessoa não foi contratada!");
    }
  }

  public void Demitir()
  {
    if (Situacao == "Contratado")
    {
      Situacao = "Demitido";
    }
    else
    {
      Console.WriteLine("Não é possível demitir alguem que não esta contratado!");
    }
  }
  #endregion
}