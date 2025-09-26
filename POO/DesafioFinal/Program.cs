
/// Para entender, vamos usar isso para validar depois, estamos inicializando como null
/// isso quer dizer que nao tem nenhuma tag criada!
Tag tag = null;
Veiculo veiculo = null;
Pedagio pedagio = new Pedagio();

string opcao;
do
{
  Console.WriteLine("\n=== MENU PRINCIPAL ===");
  Console.WriteLine("1 - Criar TAG");
  Console.WriteLine("2 - Criar Veículo");
  Console.WriteLine("3 - Carregar Saldo");
  Console.WriteLine("4 - Exibir Saldo");
  Console.WriteLine("5 - Passar no Pedágio");
  Console.WriteLine("6 - Alterar Placa do Veículo");
  Console.WriteLine("s - Sair");
  Console.Write("Escolha uma opção: ");
  opcao = Console.ReadLine();

  Console.WriteLine();

  switch (opcao)
  {
    case "1":
      Console.Write("Informe a identificação da TAG: ");
      int idenTag = int.Parse(Console.ReadLine());
      tag = new Tag(idenTag);
      Console.WriteLine($"TAG criada com sucesso! ID: {tag.Identificacao}");
      break;

    case "2":
      if (tag == null)
      {
        Console.WriteLine("Crie uma TAG primeiro!");
        break;
      }
      Console.Write("Informe a placa: ");
      string placa = Console.ReadLine();

      Console.Write("Informe o modelo: ");
      string modelo = Console.ReadLine();

      Console.Write("Informe a marca: ");
      string marca = Console.ReadLine();

      veiculo = new Veiculo(placa, modelo, marca);
      veiculo.AssociarTAG(tag);
      Console.WriteLine($"Veículo {veiculo.Placa} criado e TAG associada!");
      break;

    case "3":
      if (tag == null)
      {
        Console.WriteLine("Crie uma TAG primeiro!");
        break;
      }
      Console.Write("Informe o valor para recarga: ");
      decimal valor = decimal.Parse(Console.ReadLine());
      tag.RecarregarSaldo(valor);
      break;

    case "4":
      if (tag == null)
      {
        Console.WriteLine("Crie uma TAG primeiro!");
        break;
      }
      tag.ObterSaldo();
      break;

    case "5":
      if (veiculo == null)
      {
        Console.WriteLine("Crie um veículo com TAG primeiro!");
        break;
      }
      pedagio.PassarPedagio(veiculo);
      break;

    case "6":
      if (veiculo == null)
      {
        Console.WriteLine("Crie um veículo primeiro!");
        break;
      }
      Console.Write("Informe a nova placa: ");
      string novaPlaca = Console.ReadLine();
      veiculo.AlterarPlaca(novaPlaca);
      break;

    case "s":
      Console.WriteLine("Saindo do sistema...");
      break;

    default:
      Console.WriteLine("Opção inválida!");
      break;
  }

} while (opcao != "s");
