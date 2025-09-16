public class Gerente : FuncionarioBase
{
  #region Propriedade
  public string Departamento { get; set; }
  #endregion

  #region Contrutores
  public Gerente(string nome, decimal salario, string situacao) : base(nome, salario, situacao)
  {
  }
  public Gerente(string nome, decimal salario, string situacao, string departamento) : this(nome, salario, situacao)
  {
    Departamento = departamento;
  }
  #endregion

  #region Metodos
  public override void DarAumento(decimal valor)
  {
    if (Situacao == "Contratado")
    {
      Salario += valor;
      Salario += Salario * 0.25m;
    }
    else
    {
      Console.WriteLine("A pessoa não foi contratada!");
    }
  }
  #endregion
}