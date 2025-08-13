string?[] nomes = new string?[10];
string?[] telefones = new string?[10];
int quantidadeContatos = 0;

void AdicionarContato()
{
  if (quantidadeContatos >= 10)
  {
    Console.WriteLine("--- A AGENDA ESTÁ CHEIA ---\n");
    return;
  }

  Console.Write("--- Digite o nome do contato: ");
  string nome = Console.ReadLine()!;
  Console.Write("--- Digite o telefone do contato (xx)xxxxx-xxxx: ");
  string telefone = Console.ReadLine()!;

  nomes[quantidadeContatos] = nome;
  telefones[quantidadeContatos] = telefone;
  quantidadeContatos++;
}

void RemoverContato()
{
  if (quantidadeContatos == 0)
  {
    Console.WriteLine("--- A AGENDA ESTÁ VAZIA ---\n");
    return;
  }

  Console.Write("--- Digite o nome do contato que deseja remover: ");
  string nomeParaRemover = Console.ReadLine()!;
  int indiceParaRemover = -1;

  for (int i = 0; i < quantidadeContatos; i++)
  {
    if (nomes[i]!.Equals(nomeParaRemover, StringComparison.OrdinalIgnoreCase)) // ignora letras maiusculas e minusculas
    {
      indiceParaRemover = i; // paga o indice do contato para remover
      break;
    }
  }

  if (indiceParaRemover == -1)
  {
    Console.WriteLine("Contato não encontrado.");
    return;
  }

  string nomeRemovido = nomes[indiceParaRemover]!;
  for (int i = indiceParaRemover; i < quantidadeContatos - 1; i++)
  {
    nomes[i] = nomes[i + 1]; // copia para tras
    telefones[i] = telefones[i + 1];
  }

  nomes[quantidadeContatos - 1] = null;
  telefones[quantidadeContatos - 1] = null;
  quantidadeContatos--;

  Console.WriteLine($"--- {nomeRemovido} removido com sucesso! ---\n");
}

void ListarContatos()
{
  if (quantidadeContatos == 0)
  {
    Console.WriteLine("--- A AGENDA ESTÁ VAZIA --- \n");
    return;
  }

  Console.WriteLine("\n--- Lista de Contatos ---");
  for (int i = 0; i < quantidadeContatos; i++)
  {
    Console.WriteLine($"--- {i + 1} | {nomes[i]} - {telefones[i]}");
  }
}



bool encerrarCodigo = false;

while (!encerrarCodigo)
{
  Console.WriteLine("\n--- AGENDA DE CONTATOS ---");
  Console.WriteLine("1 - Adicionar contato");
  Console.WriteLine("2 - Remover contato");
  Console.WriteLine("3 - Listar contatos");
  Console.WriteLine("4 - Sair");
  Console.Write("Escolha uma opção: ");

  string opcao = Console.ReadLine()!;

  switch (opcao)
  {
    case "1":
      AdicionarContato();
      break;
    case "2":
      RemoverContato();
      break;
    case "3":
      ListarContatos();
      break;
    case "4":
      encerrarCodigo = true;
      Console.WriteLine("Saindo do programa...");
      break;
    default:
      Console.WriteLine("--- OPÇÃO INVÁLIDA, TENTE NOVAMENTE! ---");
      break;
  }
}