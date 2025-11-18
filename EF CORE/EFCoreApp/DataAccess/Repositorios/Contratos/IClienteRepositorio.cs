using Dominio;

public interface IClienteRepositorio
{
  int Salvar(Cliente cliente);
  void Atualizar(Cliente cliente);
  Cliente Obter(int clienteId);
  Cliente ObterPorEmail(string email);
  IEnumerable<Cliente> Listar (bool ativo);
}