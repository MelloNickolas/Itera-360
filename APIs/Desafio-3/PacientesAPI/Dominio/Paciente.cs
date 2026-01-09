namespace Dominio;

public class Paciente
{
  public int IDPaciente { get; set; }
  public string Nome { get; set; }
  public DateTime DataNascimento { get; set; }
  public bool Ativo { get; set; }
}