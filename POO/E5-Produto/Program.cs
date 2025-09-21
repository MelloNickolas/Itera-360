var primeiroProduto = new Produto("Shampoo", 10m, 10);

Console.WriteLine($"{primeiroProduto.Nome} | {primeiroProduto.Preco} | {primeiroProduto.Quantidade}");

primeiroProduto.MudarPreco(100m);
primeiroProduto.MudarQuantidade(20);

Console.WriteLine($"{primeiroProduto.Nome} | {primeiroProduto.Preco} | {primeiroProduto.Quantidade}");
