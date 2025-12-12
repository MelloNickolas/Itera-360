using dominio;
using System.Collections.Generic;

public interface IItemRepositorio
{
    int Salvar(Item item);
    void Atualizar(Item item);
    void Excluir(int itemId);

    Item Obter(int itemId);

    IEnumerable<Item> ListarTodos();
    IEnumerable<Item> ListarDisponiveis();
    IEnumerable<Item> ListarIndisponiveis();
}
