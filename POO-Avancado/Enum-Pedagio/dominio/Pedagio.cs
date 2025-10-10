public static class Pedagio
{
  private static decimal ValorPedagio;
  public static int PassagensComSucesso { get; private set; }
  public static int TentativasSemSaldo { get; private set; }


  public static bool PassarPedagio(Veiculo veiculo)
  {
    switch (veiculo.TipoVeiculo)
    {
      case TipoVeiculo.Moto:
        ValorPedagio = 1.50m;
        break;

      case TipoVeiculo.Carro:
        ValorPedagio = 2.90m;
        break;

      case TipoVeiculo.Caminhao:
        ValorPedagio = 18.90m;
        break;

      default:
        throw new ArgumentException("Tipo de veículo desconhecido.");
    }


    // Tenta realizar o desconto do pedágio se não conseguir ele invalida a operação
    try
    {
      veiculo.Tag.DescontarSaldo(ValorPedagio);
      Console.WriteLine($"Veículo {veiculo.Placa} passou no pedágio!");
      PassagensComSucesso++;
      return true;
    }
    catch (InvalidOperationException ex)
    {
      Console.WriteLine($"Erro: {ex.Message}");
      TentativasSemSaldo++;
      return false;
    }
  }


  public static bool VerificarCancela(Tag tag)
  {
    // Não da para verificar uma TAG nula!
    if (tag == null)
      throw new ArgumentException("A TAG não pode ser nula.");

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
