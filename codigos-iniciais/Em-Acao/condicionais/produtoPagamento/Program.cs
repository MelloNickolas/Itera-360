Console.WriteLine("Digite o preço do produto:");
double preco = double.Parse(Console.ReadLine()!);

Console.WriteLine("Forma de pagamento (digite 'avista' ou 'prazo'):");
string formaPagamento = Console.ReadLine()!; 

double precoFinal;

if (formaPagamento == "avista")
{
  precoFinal = preco * 0.9;
}
else
{
  precoFinal = preco;
}

Console.WriteLine($"Preço final: R$ {precoFinal:F2}");