Console.Write("\n-----------------------");
Console.Write("\nCARDÁPIO DO DIA");
Console.Write("\n1 - Macarrão");
Console.Write("\n2 - Arroz e Feijão");
Console.Write("\n3 - Nhoque");
Console.Write("\n1 - Churrasco");
Console.Write("\n-----------------------");

decimal macarraoPreco = 29.99M;
decimal arrozefeijaoPreco = 12.99M;
decimal nhoquePreco = 22.00M;
decimal churrascoPreco = 37.90M;

Console.Write("\nQual item do cardapio voce deseja ver o preço ? (Digite o número respectivo)\n");
int itemCardapio = int.Parse(Console.ReadLine()!);

switch (itemCardapio)
{
  case 1:
    Console.WriteLine($"\nO valor do Macarrão é de R${macarraoPreco}");
    break;
  case 2:
    Console.WriteLine($"\nO valor do Arroz e Feijão é de R${arrozefeijaoPreco}");
    break;
  case 3:
    Console.WriteLine($"\nO valor do Nhoque é de R${nhoquePreco}");
    break;
  case 4:
    Console.WriteLine($"\nO valor do Churrasco é de R${churrascoPreco}");
    break;
  default:
    Console.WriteLine("\nEssa opção não existe!");
    break;
}