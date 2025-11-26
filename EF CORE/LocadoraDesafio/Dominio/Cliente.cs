namespace Dominio;

public class Cliente
{
  public int IDCliente { get; set; }
  public string Nome { get; set; }
  public string Email { get; set; }
  public string Telefone { get; set; }

  // Relacionamento 1:N → Um Cliente tem vários Aluguéis
  public List<Aluguel> Alugueis { get; set; } = new List<Aluguel>();
}