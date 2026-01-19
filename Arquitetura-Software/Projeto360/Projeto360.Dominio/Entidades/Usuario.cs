namespace Projeto360.Dominio.Entidades
{
  public class Usuario
  {
    public int IDUsuario { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public bool Ativo { get; set; }
    public Usuario()
    {
      Ativo = true;
    }

    public void Deletar()
    {
      Ativo = false;
    }
    public void Recuperar()
    {
      Ativo = true;
    }
  }
}