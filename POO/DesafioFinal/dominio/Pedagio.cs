public class Pedagio : IPedagio
{
  private decimal ValorPedagio = 2.90m;

  public bool PassarPedagio(Veiculo veiculo)
  {
    if (veiculo.Tag.Saldo >= ValorPedagio)
    {
      veiculo.Tag.DescontarSaldo(ValorPedagio);
      Console.WriteLine($"Veículo {veiculo.Placa} passou no pedágio!");
      return true;
    }
    else
    {
      Console.WriteLine($"Saldo insuficiente para o veículo {veiculo.Placa}!");
      return false;
    }
  }

  public bool VerificarCancela(Tag tag)
  {
    if (tag.Saldo >= ValorPedagio)
    {
      Console.WriteLine("Cancela liberada");
      return true;
    }
    else
    {
      Console.WriteLine("Cancela bloqueada -- Saldo insuficiente");
      return false;
    }
  }
}