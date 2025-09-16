public class Gerente : Funcionario
{
  #region Propriedade
  public string Departamento { get; set; }
  #endregion

  #region Contrutores
  public Gerente(string nome, decimal salario, string situacao, string departamento) : base(nome, salario, situacao)
  {
    Departamento = departamento;
  }

  #endregion

  #region Metodos
  public override void DarAumento(decimal valor)
  {
    if (Situacao == "Contratado")
    {
      Salario += Salario * 0.25m;
      Salario += valor;
    }
    else
    {
      Console.WriteLine("A pessoa não foi contratada!");
    }
  }
  #endregion
}