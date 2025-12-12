using dominio;
using System.Collections.Generic;

public interface IUsuarioRepositorio
{
    int Salvar(Usuario usuario);
    void Atualizar(Usuario usuario);

    Usuario Obter(int usuarioId);
    Usuario ObterPorNome(string nome);

    IEnumerable<Usuario> ListarTodos();
}
