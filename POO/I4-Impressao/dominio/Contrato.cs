
public class Contrato : IImprimivel
{
    public string Numero { get; set; }

    public void Imprimir()
    {
        Console.WriteLine($"Imprimindo contrato: {Numero}");
    }
}