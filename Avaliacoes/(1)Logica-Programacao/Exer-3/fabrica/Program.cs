Console.WriteLine("Qual o nome do cliente ? ");
string nomeCliente = Console.ReadLine()!;

Console.WriteLine($"Qual a cidade do/da {nomeCliente} ? ");
string cidadeCliente = Console.ReadLine()!;

for (int porcentagem = 1; porcentagem <= 100; porcentagem++)
{
  Console.WriteLine($"{porcentagem}%");
  if (porcentagem == 25)
  {
    Console.WriteLine($"Estamos a 25% do seu pedido! Aproveite um café enquanto espera em {cidadeCliente}!");
  }
  else if (porcentagem == 50)
  {
    Console.WriteLine($"Estamos a 50% do seu pedido! Aproveite a vista maravilhosa de {cidadeCliente} enquanto espera!");
  }
  else if (porcentagem == 75)
  {
    Console.WriteLine($"Estamos a 75% do seu pedido! Que tal um lanche enquanto espera em {cidadeCliente}?");
  }
  else if (porcentagem == 90)
  {
    Console.WriteLine($"Estamos a 90% do seu pedido! Estamos quase lá");
  }
}

Console.WriteLine($"O pedido do/da {nomeCliente} foi concluido com sucesso! ");