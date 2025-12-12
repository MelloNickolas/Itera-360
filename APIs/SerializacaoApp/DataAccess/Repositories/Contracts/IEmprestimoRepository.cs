using dominio;
using System.Collections.Generic;

public interface IEmprestimoRepositorio
{
    int Salvar(Emprestimo emprestimo);
    void Atualizar(Emprestimo emprestimo);

    Emprestimo Obter(int emprestimoId);

    IEnumerable<Emprestimo> Listar();
    IEnumerable<Emprestimo> ListarPorUsuario(int usuarioId);
    IEnumerable<Emprestimo> ListarPorItem(int itemId);

    void MarcarComoDevolvido(int emprestimoId);
}
