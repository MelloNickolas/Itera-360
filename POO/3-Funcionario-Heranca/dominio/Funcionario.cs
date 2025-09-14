public class Funcionario
{
  #region Atributos
  public string _nome;
  public int _matricula;
  public decimal _salario;
  #endregion

  #region propriedade
  public string Nome
  {
    get { return _nome; }
    set { _nome = value; }
  }
  public int Matricula
  {
    get { return _matricula; }
    private set { _matricula = value; } // encapsulada
  }

  public decimal Salario
  {
    get { return _salario; }
    private set { _salario = value; } // encapsulada
  }

  #endregion

  #region Métodos
  public void DarAumento(decimal valorAumento)
  {
    Salario += valorAumento;
    Console.WriteLine($"{Nome} recebeu um aumento de R${valorAumento}. Agora o novo salário é de : R${Salario}");
  }

  public void ExibirNomeSalario()
  {
    Console.WriteLine($"{Nome} | {Salario}");
  }
  #endregion

  #region Construtor
  public Funcionario(string nome, decimal salario)
  {
    Nome = nome;
    Salario = salario;

    Random randomNumber = new Random();
    Matricula = randomNumber.Next(1, 100);
  }
  #endregion
}

