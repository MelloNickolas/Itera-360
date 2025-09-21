public class Boleto : IPagamento
{
    public string CodigoBoleto { get; set; }
    public DateTime DataVencimento { get; set; }

    public void Pagar()
    {
        Console.WriteLine("Pagamento realizado via boleto.");
    }

    public void CancelarPagamento()
    {
        Console.WriteLine("Pagamento do boleto cancelado.");
    }
}
