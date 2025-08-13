Console.WriteLine("Qual o preço do produto em R$");
double preco = double.Parse(Console.ReadLine()!);

Console.WriteLine("Qual a porcentagem de desconto ?");
double descontoEmPorcentagem = double.Parse(Console.ReadLine()!);

double precoComDesconto = preco - (preco * (descontoEmPorcentagem / 100));

Console.WriteLine($"O valor com desconto fica R${precoComDesconto}");