int?[] numsTag = new int?[10];
double?[] saldosTag = new double?[10];
int quantidadeTags = 0;

void CadastrarTag()
{
  if (quantidadeTags >= 10)
  {
    Console.WriteLine("--- NOSSO INVENTÁRIO ESTÁ LOTADO, NÃO PODEMOS MAIS CADSTRAR TAGS! ---\n");
    return;
  }

  Console.Write("--- Qual o número da Tag que você deseja cadastrar : ");
  int numTag = int.Parse(Console.ReadLine()!);
  numsTag[quantidadeTags] = numTag;

  Console.Write($"--- Qual o saldo da Tag {numTag} ? ");
  double saldoTag = double.Parse(Console.ReadLine()!);
  saldosTag[quantidadeTags] = saldoTag;

  Console.WriteLine($"TAG {numTag} foi registrada com um saldo de R${saldoTag}");
  quantidadeTags++;
}

void RemoverTag()
{
  int indiceParaRemoverTag = -1;
  int? numeroTagParaRemover;

  if (quantidadeTags == 0)
  {
    Console.WriteLine("--- NÃO POSSUEM TAGS PARA EXCLUIR! ---\n");
    return;
  }

  VerSaldoTags();

  Console.Write("--- Digite o número da TAG que deseja remover : ");
  numeroTagParaRemover = int.Parse(Console.ReadLine()!);

  for (int i = 0; i < quantidadeTags; i++)
  {
    if (numsTag[i] == numeroTagParaRemover)
    {
      indiceParaRemoverTag = i;
      break;
    }
  }

  if (indiceParaRemoverTag == -1)
  {
    Console.WriteLine("\n--- A TAG NÃO FOI ENCONTRADA ---");
    return;
  }

  for (int i = indiceParaRemoverTag; i < quantidadeTags - 1; i++)
  {
    numsTag[i] = numsTag[i + 1];
    saldosTag[i] = saldosTag[i + 1];
  }

  numsTag[quantidadeTags - 1] = null;
  saldosTag[quantidadeTags - 1] = null;
  quantidadeTags--;

  Console.WriteLine($"--- A TAG {numeroTagParaRemover} foi removida com sucesso! --- ");
}

void CarregarSaldoTag()
{
  if (quantidadeTags == 0)
  {
    Console.WriteLine("--- NÃO POSSUEM TAGS PARA CARREGAR! ---\n");
    return;
  }

  VerSaldoTags();

  Console.WriteLine("--- Qual o número da Tag que você deseja carregar ? ");
  int tagParaCarregar = int.Parse(Console.ReadLine()!);

  for (int i = 0; i < quantidadeTags; i++)
  {
    if (numsTag[i] == tagParaCarregar)
    {
      Console.WriteLine($"Quanto de saldo você deseja adicionar na tag {numsTag[i]} ? ");
      double saldoParaCarregar = double.Parse(Console.ReadLine()!);

      saldosTag[i] += saldoParaCarregar;

      Console.WriteLine($"--- O novo saldo da TAG {numsTag[i]} é de R${saldosTag[i]}");
    }
  }

}

void VerSaldoTags()
{
  if (quantidadeTags == 0)
  {
    Console.WriteLine("--- NÃO POSSUEM TAGS PARA EXIBIR! ---\n");
    return;
  }

  Console.WriteLine("--- TAGS NO ESTOQUE ---");
  for (int i = 0; i < quantidadeTags; i++)
  {
    Console.Write($"| {numsTag[i]} - R${saldosTag[i]} |");
  }
}

void PassagemPedagio()
{
  if (quantidadeTags == 0)
  {
    Console.WriteLine("--- NÃO POSSUEM TAGS PARA PASSA PELO PEDÁGIO! ---\n");
    return;
  }

  VerSaldoTags();

  Console.WriteLine("\n--- Qual no múmero da TAG que você deseja para passa no PEDÁGIO ?");
  int tagParaPedagio = int.Parse(Console.ReadLine()!);

  for (int i = 0; i < quantidadeTags; i++)
  {
    if (numsTag[i] == tagParaPedagio)
    {
      Console.WriteLine("--- Qual o valor do pedágio que você irá passar ?");
      double valorPedagio = double.Parse(Console.ReadLine()!);

      if (saldosTag[i] > valorPedagio)
      {
        saldosTag[i] -= valorPedagio;
        Console.WriteLine($"O pedágio de {valorPedagio} foi passado! O novo saldo da TAG {numsTag[i]} é de R${saldosTag[i]}! ");
        return;
      }
      else
      {
        Console.WriteLine("--- O VALOR FOI INSUFICIENTE ! ---");
        return;
      }
    }
  }
  Console.WriteLine("--- TAG NÃO ENCONTRADA ---");
}

bool encerrarprograma = false;

while (!encerrarprograma)
{
  Console.WriteLine("\n--- MENU DAS TAGS ---");
  Console.WriteLine("1 - Cadastrar nova TAG");
  Console.WriteLine("2 - Remover TAG");
  Console.WriteLine("3 - Carregar TAG");
  Console.WriteLine("4 - Ver saldos das TAGs");
  Console.WriteLine("5 - Passa pelo pedágio");
  Console.WriteLine("6 - Sair");

  Console.Write("Escolha uma opção: ");
  int opcaoPrograma = int.Parse(Console.ReadLine()!);



  switch (opcaoPrograma)
  {
    case 1:
      CadastrarTag();
      break;
    case 2:
      RemoverTag();
      break;
    case 3:
      CarregarSaldoTag();
      break;
    case 4:
      VerSaldoTags();
      break;
    case 5:
      PassagemPedagio();
      break;
    case 6:
      encerrarprograma = true;
      Console.WriteLine("\n--- Programa Finalizado ---");
      break;
    default:
      Console.WriteLine("--- OPÇÃO INVÁLIDA, TENTE NOVAMENTE! ---");
      break;
  }

}