using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data;
using Dapper;
using DataAccess;
using dominio;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class ItemRepositorio : IItemRepositorio
    {
        private readonly IDbConnection _conexao;

        public ItemRepositorio(Contexto contexto)
        {
            _conexao = contexto.Database.GetDbConnection();

            if (_conexao.State != ConnectionState.Open)
                _conexao.Open();
        }

        public int Salvar(Item item)
        {
            const string sql = @"
                INSERT INTO Itens (Nome, Disponivel)
                OUTPUT inserted.IDItem
                VALUES (@Nome, @Disponivel);
            ";

            return _conexao.QuerySingle<int>(sql, item);
        }

        public void Atualizar(Item item)
        {
            const string sql = @"
                UPDATE Itens
                SET 
                    Nome = @Nome,
                    Disponivel = @Disponivel
                WHERE IDItem = @IDItem;
            ";

            _conexao.Execute(sql, item);
        }

        public void Excluir(int itemId)
        {
            const string sql = @"
                DELETE FROM Itens
                WHERE IDItem = @IDItem;
            ";

            _conexao.Execute(sql, new { IDItem = itemId });
        }

        public Item Obter(int itemId)
        {
            const string sql = @"
                SELECT * FROM Itens
                WHERE IDItem = @IDItem;
            ";

            return _conexao.QuerySingleOrDefault<Item>(sql, new { IDItem = itemId });
        }

        public IEnumerable<Item> ListarTodos()
        {
            const string sql = @"SELECT * FROM Itens;";
            return _conexao.Query<Item>(sql).ToList();
        }

        public IEnumerable<Item> ListarDisponiveis()
        {
            const string sql = @"
                SELECT * FROM Itens
                WHERE Disponivel = 1;
            ";

            return _conexao.Query<Item>(sql).ToList();
        }

        public IEnumerable<Item> ListarIndisponiveis()
        {
            const string sql = @"
                SELECT * FROM Itens
                WHERE Disponivel = 0;
            ";

            return _conexao.Query<Item>(sql).ToList();
        }
    }
}
