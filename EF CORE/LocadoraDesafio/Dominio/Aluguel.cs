namespace Dominio;

public class Aluguel
{
  public int IDAluguel { get; set; }
  public DateTime DataAluguel { get; set; }
  public DateTime? DataDevolucao { get; set; }

  // one
  public int IDCliente { get; set; }
  public Cliente Cliente { get; set; }

  // Um aluguel tem vários jogos
  public List<Jogo> Jogos { get; set; } = new List<Jogo>();
}