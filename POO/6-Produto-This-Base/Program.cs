var produto = new Produto("Perfume", 100m, "Cosmético");
var produtoImportado = new ProdutoImportado("Perfume Árabe", 120m, "Cosmético", "Arabia");



Console.Write($"\n{produto.Nome} | {produto.Preco} | {produto.Categoria}");
Console.Write($"\n{produtoImportado.Nome} | {produtoImportado.Preco} | {produtoImportado.Categoria} | {produtoImportado.PaisOrigem}");