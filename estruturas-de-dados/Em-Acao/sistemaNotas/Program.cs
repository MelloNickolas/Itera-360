double[] notas = new double[10];
int quantidadeNotas = 0;

void AdicionarNota()
{
  if (quantidadeNotas >= 10)
  {
    Console.WriteLine("--- A QUANTIDADE DE NOTAS SE EXCEDEU ---\n");
    return;
  }

  Console.Write("--- Qual é a nota : ");
  double nota = double.Parse(Console.ReadLine()!); // pode colocar o numero com , que vai funcionar

  notas[quantidadeNotas] = nota;
  quantidadeNotas++;
}

void RemoverNota()
{
  if (quantidadeNotas == 0)
  {
    Console.WriteLine("---NÃO EXISTE NENHUMA NOTA! ---\n");
    return;
  }

  Console.WriteLine("--- NOTAS ARMAZENADAS ---");
  for (int i = 0; i < quantidadeNotas; i++)
  {
    Console.WriteLine($"-{i + 1}- {notas[i]}");
  }

  Console.Write("--- Digite qual nota você deseja remover : ");
  double notaParaRemover = double.Parse(Console.ReadLine()!);
  int indiceParaRemover = -1;

  for (int i = 0; i < quantidadeNotas; i++)
  {
    if (notas[i] == notaParaRemover)
    {
      indiceParaRemover = i; // paga o indice do contato para remover
      break;
    }
  }

  if (indiceParaRemover == -1)
  {
    Console.WriteLine("--- NOTA NÃO ENCONTRADA ---\n");
    return;
  }

  for (int i = indiceParaRemover; i < quantidadeNotas - 1; i++)
  {
    notas[i] = notas[i + 1]; // copia para tras
  }

  quantidadeNotas--;
  Console.WriteLine($"--- NOTA {notaParaRemover} REMOVIDA COM SUCESSO! ---\n");
}

void CalcularMedia()
{
  if (quantidadeNotas == 0)
  {
    Console.WriteLine("--- NÃO HÁ NOTAS PARA CALCULAR MÉDIA ---\n");
    return;
  }

  double soma = 0;
  for (int i = 0; i < quantidadeNotas; i++)
  {
    soma += notas[i];
  }

  double media = soma / quantidadeNotas;
  Console.WriteLine($"--- A média das {quantidadeNotas} notas é: {media:F2} ---\n");
}


bool encerrar = false;

while (!encerrar)
{
  Console.WriteLine("\n--- GERENCIADOR DE NOTAS ---");
  Console.WriteLine("1 - Adicionar nota");
  Console.WriteLine("2 - Remover nota");
  Console.WriteLine("3 - Calcular Média");
  Console.WriteLine("4 - Sair");
  Console.Write("Escolha uma opção: ");

  string opcao = Console.ReadLine()!;

  switch (opcao)
  {
    case "1":
      AdicionarNota();
      break;
    case "2":
      RemoverNota();
      break;
    case "3":
      CalcularMedia();
      break;
    case "4":
      encerrar = true;
      Console.WriteLine("Saindo do programa...");
      break;
    default:
      Console.WriteLine("--- OPÇÃO INVÁLIDA ---");
      break;
  }
}