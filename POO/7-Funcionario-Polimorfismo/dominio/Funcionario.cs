public class Funcionario : FuncionarioBase
{
  #region Construtores
  public Funcionario(string nome, decimal salario, string situacao) : base(nome, salario, situacao)
  {
  }
  #endregion

  #region Metodos
  public override void DarAumento(decimal valor)
  {
    if (Situacao == "Contratado")
    {
      Salario += valor;
      Salario += Salario * 0.1m;
    }
    else
    {
      Console.WriteLine("A pessoa não foi contratada!");
    }
  }
  #endregion
}