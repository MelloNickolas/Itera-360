public class Cliente
{
  #region Propriedades
  public string Nome { get; set; }
  public string Endereco { get; set; }
  public string Telefone { get; private set; }
  #endregion

  #region Construtores
  public Cliente(string nome, string endereco, string telefone)
  {
    Nome = nome;
    Endereco = endereco;
    Telefone = telefone;
  }
  #endregion

  #region Métodos
  public void SetTelefone(string value)
  {
    Telefone = value;
  }
  #endregion
}

