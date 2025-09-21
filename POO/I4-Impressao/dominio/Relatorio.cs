public class Relatorio : IImprimivel
{
  public string Titulo { get; set; }

  public void Imprimir()
  {
    Console.WriteLine($"Imprimindo relatório: {Titulo}");
  }
}
