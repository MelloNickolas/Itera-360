public class CartaoCredito : IPagamento
{
  public string NumeroCartao { get; set; }
  public string Titular { get; set; }

  public void Pagar()
  {
    Console.WriteLine("Pagamento realizado com cartão de crédito.");
  }

  public void CancelarPagamento()
  {
    Console.WriteLine("Pagamento com cartão de crédito cancelado.");
  }
}
