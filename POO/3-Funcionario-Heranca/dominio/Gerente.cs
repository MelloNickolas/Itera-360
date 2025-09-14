public class Gerente : Funcionario
{
  #region Propriedades
  public string Departamento { get; private set; }
  // tem como puxar uma propriedade direta, porem o atributo é Departamento, nao _departamento                                              
  #endregion

  #region Construtor
  public Gerente(string nome, decimal salario, string departamento) : base(nome, salario)
  {
    Departamento = departamento;
  }
  #endregion

  #region Métodos
  public void PromoverSubordinado(Funcionario funcionario)
  // aqui eu falo para ele receber um objeto Funcionário a outra classe que eu fiz, sendo assim ele vai se chamar
  /// funcionario, para noa confundir, esse método so vai funcionar se tiver o objeto funcionário.
  {
    Console.WriteLine($"O gerente {Nome} promoveu o funcionário {funcionario.Nome}");
  }

  public void ExibirGerente()
  // Como vou só mostrar dados de um objeto Gerente, nao preciso passar parametros pois o objeto ja foi criado
  {
    Console.WriteLine($"Nome: {Nome} | Salario: {Salario} | Departamento: {Departamento}");
  }
  #endregion
}