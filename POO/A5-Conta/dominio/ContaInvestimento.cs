public class ContaInvestimento : Conta
{
    public ContaInvestimento(decimal saldo) : base(saldo) { }

    public override decimal CalcularJuros()
    {
        return Saldo * 0.012m;
    }
}