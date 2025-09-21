
public abstract class Conta
{
    public decimal Saldo { get; set; }
    public Conta(decimal saldo)
    {
        Saldo = saldo;
    }
    public abstract decimal CalcularJuros();
}
