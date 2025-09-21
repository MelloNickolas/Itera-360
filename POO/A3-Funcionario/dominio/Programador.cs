public class Programador : Funcionario
{
    public int HorasExtras { get; set; }
    public decimal ValorHoraExtra { get; set; }

    public Programador(string nome, decimal salarioBase, int horasExtras, decimal valorHoraExtra) : base(nome, salarioBase)
    {
        HorasExtras = horasExtras;
        ValorHoraExtra = valorHoraExtra;
    }

    public override decimal CalcularSalario()
    {
        return SalarioBase + (HorasExtras * ValorHoraExtra);
    }
}