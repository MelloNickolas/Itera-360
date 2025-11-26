namespace Dominio;

public class Jogo
{
  public int IDJogo { get; set; }
  public string Nome { get; set; }
  public string Genero { get; set; }
  public string Plataforma { get; set; }
  public string Disponibilidade { get; set; }


  // FK — um jogo só pode estar em um aluguel
  public int? IDAluguel { get; set; }
  public Aluguel Aluguel { get; set; }
}