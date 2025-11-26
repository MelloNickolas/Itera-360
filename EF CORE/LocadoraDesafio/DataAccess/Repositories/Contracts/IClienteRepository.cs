using Dominio;

public interface IClienteRepository
{
  int CreateCliente(Cliente cliente);
  void UpdateCliente(Cliente cliente);
  Cliente GetClienteByID(int idCliente);
  void DeleteClienteByID(int idCliente);
}