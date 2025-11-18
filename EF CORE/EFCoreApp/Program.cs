using DataAccess;
using Dominio;

public partial class Program
{
  public static void Main(string[] args)
  {
    using (var contexto = new Contexto())
    {
      var clienteRepositorio = new ClienteRepositorio(contexto);

      // Criar novo cliente
      var cliente = new Cliente();

      Console.Write("Digite o nome do cliente : ");
      cliente.Nome = Console.ReadLine();

      Console.Write("Digite o email do cliente : ");
      cliente.Email = Console.ReadLine();

      cliente.Ativo = true;

      // SALVAR -> retorna o ID
      cliente.Id = clienteRepositorio.Salvar(cliente);

      Console.WriteLine("Cliente adicionado com sucesso!");

      #region Busca de Cliente

      Console.Write("Digite o email do cliente que deseja encontrar : ");
      string emailBusca = Console.ReadLine();

      // BUSCAR POR EMAIL
      var clienteBanco = clienteRepositorio.ObterPorEmail(emailBusca);

      if (clienteBanco != null)
      {
        Console.WriteLine($"O cliente {clienteBanco.Nome} foi encontrado! Email: {clienteBanco.Email}");

        // Atualização
        Console.Write($"Digite o novo email do {clienteBanco.Nome} : ");
        string novoEmail = Console.ReadLine();

        clienteBanco.Email = novoEmail;

        clienteRepositorio.Atualizar(clienteBanco);

        Console.WriteLine("Cliente atualizado com sucesso!");
      }
      else
      {
        Console.WriteLine("Cliente não encontrado.");
      }

      #endregion

      #region Listagem de Clientes Ativos

      Console.WriteLine("\nClientes ativos cadastrados:");
      var clientesAtivos = clienteRepositorio.Listar(true);

      foreach (var c in clientesAtivos)
      {
        Console.WriteLine($"ID: {c.Id} | Nome: {c.Nome} | Email: {c.Email}");
      }

      #endregion
    }
  }
}
