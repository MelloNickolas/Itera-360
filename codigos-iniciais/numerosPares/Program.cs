int numeroParFor = 0;

Console.WriteLine("---- Usando FOR ----");
for (int contadorFor = 1; contadorFor <= 10; contadorFor++)
{
  numeroParFor += 2;
  Console.WriteLine($"O {contadorFor}* número par é --- {numeroParFor}");
}

int numeroParWhile = 0;
int contadorWhile = 1;

Console.WriteLine("\n---- Usando WHILE ----");
while (contadorWhile <= 10)
{
  numeroParWhile += 2;
  Console.WriteLine($"O {contadorWhile}* número par é --- {numeroParWhile}");
  contadorWhile += 1;
}

int numeroParDo = 2;
int contadorDo = 1;

Console.WriteLine("\n---- Usando DO WHILE ----");
do
{
  numeroParDo += 2;
  contadorDo += 1;
  Console.WriteLine($"O {contadorDo}* número par é --- {numeroParDo}");
} while (contadorDo < 10);