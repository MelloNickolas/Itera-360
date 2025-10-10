public static class Pedagio
{
  public static List<Passagem> Passagens { get; private set; } = new List<Passagem>();
  public static List<TentativaPassagem> Tentativas { get; private set; } = new List<TentativaPassagem>();

  public static int PassagensComSucesso { get; private set; }
  public static int TentativasSemSaldo { get; private set; }

  public static bool PassarPedagio(Veiculo veiculo)
  {
    if (veiculo.Tag == null)
      throw new ArgumentException("O veículo não possui TAG associada.");

    var passagem = new Passagem(veiculo);

    if (veiculo.Tag.Saldo >= passagem.ValorPassagem)
    {
      veiculo.Tag.DescontarSaldo(passagem.ValorPassagem);
      Passagens.Add(passagem);
      Console.WriteLine($"Veículo {veiculo.Placa} passou no pedágio!");
      PassagensComSucesso++;
      return true;
    }
    else
    {
      var tentativa = new TentativaPassagem(veiculo, "Saldo insuficiente");
      Tentativas.Add(tentativa);
      Console.WriteLine($"Veículo {veiculo.Placa} não pôde passar. {tentativa.MsgFalha}");
      TentativasSemSaldo++;
      return false;
    }
  }

  public static void ExibirRelatorio()
  {
    Console.WriteLine("\n=== RELATÓRIO DE PASSAGENS ===");
    Console.WriteLine($"Passagens com sucesso: {PassagensComSucesso}");
    Console.WriteLine($"Tentativas sem saldo: {TentativasSemSaldo}");

    Console.WriteLine("\nDetalhes das passagens:");
    foreach (var p in Passagens)
      p.MostrarValorPassagem();

    Console.WriteLine("\nDetalhes das tentativas:");
    foreach (var t in Tentativas)
      t.MostrarTentativa();
  }
}
