public class Carro : IVeiculo
{
  public string Modelo { get; set; }

  public void Acelerar()
  {
    Console.WriteLine($"O carro {Modelo} está acelerando.");
  }

  public void Frear()
  {
    Console.WriteLine($"O carro {Modelo} está freando.");
  }
}