string[] nomes = new string[5];
double[] alturas = new double[5];

// esse indice serve com um contado atual para saber a posiçao atual do topo da pilha
int indice = 0;


// vamos colocar itens na pilha
void Push(string nome, double altura)
{
  if (indice < 5)
  {
    // adiciona os dados na posiçao atual que vai ser apontada pelo indice
    nomes[indice] = nome;
    alturas[indice] = altura;

    Console.WriteLine(nome + " foi adicionado.");

    // aqui ja estamos colocando o indice 1 para adicionar o prox objeto
    indice++;
  }
  else
  {
    Console.WriteLine("Não tem mais lugar nessa pilha!");
  }
}

// vamos tirar intens da pilha
void Pop()
{
  if (indice > 0)
  {
    // vamos tirar o indice para o prox objeto
    indice--;

    Console.WriteLine("\n" + nomes[indice] + " foi apagado");

    // limpa as informacoes a nossa pilha
    nomes[indice] = string.Empty;
    alturas[indice] = 0;
  }
  else
  {
    Console.WriteLine("\nNão tem como remover nada, está vazio!");
  }
}

Push("Nickolas", 1.72);
Push("Leandro", 1.82);
Push("Rafaela", 1.65);
Push("Carlos", 1.77);
Push("Claudineia", 1.40);

// vamos mostrar o topo da pilha
Console.WriteLine("\nO topo da pilha é :");
Console.WriteLine("Nome: " + nomes[indice -1]); // coloco menos 1 pq os indices da pilha tao assim [0, 1, 2 , 3, 4], como o indice rodou 5 vezes ele é 5
Console.WriteLine("Altura: " + alturas[indice - 1]);

Pop(); // agora vai remover o topo que é a CLAUDINEIA

Console.WriteLine("WNome: " + nomes[indice -1]);
Console.WriteLine("Altura: " + alturas[indice - 1]);
