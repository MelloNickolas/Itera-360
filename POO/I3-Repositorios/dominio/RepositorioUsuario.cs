public class RepositorioUsuario : IRepositorio
{
    public void Adicionar()
    {
        Console.WriteLine("Usuário adicionado.");
    }

    public void Atualizar()
    {
        Console.WriteLine("Usuário atualizado.");
    }

    public void Remover()
    {
        Console.WriteLine("Usuário removido.");
    }
}