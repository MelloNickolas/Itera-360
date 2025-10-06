public static class Pedagio
{
  private static decimal ValorPedagio = 2.90m;

  public static int PassagensComSucesso { get; private set; }
  public static int TentativasSemSaldo { get; private set; }


  public static bool PassarPedagio(Veiculo veiculo)
  {
    if (veiculo.Tag.Saldo >= ValorPedagio)
    {
      veiculo.Tag.DescontarSaldo(ValorPedagio);
      Console.WriteLine($"Veículo {veiculo.Placa} passou no pedágio!");
      PassagensComSucesso++;
      return true;
    }
    else
    {
      Console.WriteLine($"Saldo insuficiente para o veículo {veiculo.Placa}!");
      TentativasSemSaldo++;
      return false;
    }
  }

  public static bool VerificarCancela(Tag tag)
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

  public static void ExibirRelatorio()
  {
    Console.WriteLine("\nRELATÓRIO DE PASSAGENS");
    Console.WriteLine($"→ Passagens com sucesso: {PassagensComSucesso}");
    Console.WriteLine($"→ Tentativas sem saldo: {TentativasSemSaldo}");
  }
}