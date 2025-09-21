class Program
{
  static void Main()
  {
    var cartao = new CartaoCredito { NumeroCartao = "1234 5678 9012 3456", Titular = "Nickolas" };
    var boleto = new Boleto { CodigoBoleto = "00123456789", DataVencimento = DateTime.Today.AddDays(7) };

    cartao.Pagar();
    boleto.Pagar();

    cartao.CancelarPagamento();
    boleto.CancelarPagamento();
  }
}
