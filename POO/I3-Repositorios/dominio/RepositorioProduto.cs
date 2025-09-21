public class RepositorioProduto : IRepositorio
{
  public void Adicionar()
  {
    Console.WriteLine("Produto adicionado.");
  }

  public void Atualizar()
  {
    Console.WriteLine("Produto atualizado.");
  }

  public void Remover()
  {
    Console.WriteLine("Produto removido.");
  }
}