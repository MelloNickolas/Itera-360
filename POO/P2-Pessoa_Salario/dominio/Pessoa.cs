public class Pessoa
{
  #region Atributos
  public string _nome;
  public int _idade;
  public decimal _salario;
  #endregion

  #region Propriedades
  public string Nome
  {
    get { return _nome; }
    set { _nome = value; }
  }
  public int Idade
  {
    get { return _idade; }
    set { _idade = value; }
  }
  public decimal Salario
  {
    get { return _salario; }
    private set { _salario = value; }
  }
  #endregion
}

