public class Moto : IVeiculo
{
    public string Modelo { get; set; }

    public void Acelerar()
    {
        Console.WriteLine($"A moto {Modelo} está acelerando.");
    }

    public void Frear()
    {
        Console.WriteLine($"A moto {Modelo} está freando.");
    }
}