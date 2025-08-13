
int gerarNumeroAleatorio()
{
  Random gerador = new Random();
  int numeroAleatorio = gerador.Next(1, 101);
  return numeroAleatorio;
}
bool verificaPalpiteCerto(int palpite, int numeroAleatorio)
{
  if (palpite < numeroAleatorio)
  {
    Console.WriteLine("O número aleatório é MAIOR.");
    return false;
  }
  else if (palpite > numeroAleatorio)
  {
    Console.WriteLine("O número aleatório é MENOR.");
    return false;
  }
  else
  {
    Console.WriteLine($"Você acertou! O número secreto era {numeroAleatorio}");
    return true;
  }
}


string jogarDenovo;
do
{
  int tentativas = 0;
  int numeroAleatorio = gerarNumeroAleatorio();
  bool acertou = false;
  int pontos = 100;

  do
  {
    Console.WriteLine("Digite seu número INTEIRO : ");
    int palpite = int.Parse(Console.ReadLine()!);

    tentativas++;
    pontos -= 100;
    acertou = verificaPalpiteCerto(palpite, numeroAleatorio);
    Console.WriteLine();

  } while (!acertou && tentativas < 10);

  Console.WriteLine($"Você acertou em {tentativas} tentativa(s)!");


  if (!acertou)
  {
    Console.WriteLine($"Suas 10 tentativas acabaram! O número secreto era {numeroAleatorio}.");
  }
  else
  {
    Console.WriteLine($"Você acertou em {tentativas} tentativas e ganhou {pontos} pontos!");
  }

  Console.Write("Deseja jogar novamente? (s para sim / n para não): ");
  jogarDenovo = Console.ReadLine()!;
} while (jogarDenovo == "s");

Console.WriteLine("\n--------JOGO FINALIZADO--------");