namespace Dominio;

public class Cliente
{
  public int Id { get; set; }
  public string Nome { get; set; }
  public string Email { get; set; }
  public bool Ativo { get; set; }

  //Many, muitos do relacionamento
  public List<Pedido> Pedidos { get; set; }
}