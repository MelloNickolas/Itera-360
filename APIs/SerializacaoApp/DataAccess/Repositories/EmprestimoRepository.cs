using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data;
using Dapper;
using DataAccess;
using dominio;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DataAccess.Repositories
{
    public class EmprestimoRepositorio : IEmprestimoRepositorio
    {
        private readonly IDbConnection _conexao;

        public EmprestimoRepositorio(Contexto contexto)
        {
            _conexao = contexto.Database.GetDbConnection();

            if (_conexao.State != ConnectionState.Open)
                _conexao.Open();
        }

        public int Salvar(Emprestimo emprestimo)
        {
            const string sql = @"
                INSERT INTO Emprestimos 
                    (IDUsuario, IDItem, DataEmprestimo, DataDevolucaoPrevista, DataDevolucaoReal, Devolvido)
                OUTPUT inserted.IDEmprestimo
                VALUES 
                    (@IDUsuario, @IDItem, @DataEmprestimo, @DataDevolucaoPrevista, @DataDevolucaoReal, @Devolvido);
            ";

            return _conexao.QuerySingle<int>(sql, emprestimo);
        }

        public void Atualizar(Emprestimo emprestimo)
        {
            const string sql = @"
                UPDATE Emprestimos
                SET 
                    IDUsuario = @IDUsuario,
                    IDItem = @IDItem,
                    DataEmprestimo = @DataEmprestimo,
                    DataDevolucaoPrevista = @DataDevolucaoPrevista,
                    DataDevolucaoReal = @DataDevolucaoReal,
                    Devolvido = @Devolvido
                WHERE IDEmprestimo = @IDEmprestimo;
            ";

            _conexao.Execute(sql, emprestimo);
        }

        public Emprestimo Obter(int emprestimoId)
        {
            const string sql = @"
                SELECT * FROM Emprestimos
                WHERE IDEmprestimo = @IDEmprestimo;
            ";

            return _conexao.QuerySingleOrDefault<Emprestimo>(sql, new { IDEmprestimo = emprestimoId });
        }

        public IEnumerable<Emprestimo> Listar()
        {
            const string sql = @"SELECT * FROM Emprestimos;";
            return _conexao.Query<Emprestimo>(sql).ToList();
        }

        public IEnumerable<Emprestimo> ListarPorUsuario(int usuarioId)
        {
            const string sql = @"
                SELECT * FROM Emprestimos
                WHERE IDUsuario = @IDUsuario;
            ";

            return _conexao.Query<Emprestimo>(sql, new { IDUsuario = usuarioId }).ToList();
        }

        public IEnumerable<Emprestimo> ListarPorItem(int itemId)
        {
            const string sql = @"
                SELECT * FROM Emprestimos
                WHERE IDItem = @IDItem;
            ";

            return _conexao.Query<Emprestimo>(sql, new { IDItem = itemId }).ToList();
        }

        public void MarcarComoDevolvido(int emprestimoId)
        {
            // Regra do exercício:
            // - marcar empréstimo como devolvido
            // - atualizar o item correspondente para Disponivel = 1

            const string sqlEmprestimo = @"
                UPDATE Emprestimos
                SET Devolvido = 1,
                    DataDevolucaoReal = @DataDevolucaoReal
                WHERE IDEmprestimo = @IDEmprestimo;
            ";

            const string sqlItem = @"
                UPDATE Itens
                SET Disponivel = 1
                WHERE IDItem = (
                    SELECT IDItem FROM Emprestimos WHERE IDEmprestimo = @IDEmprestimo
                );
            ";

            using var transacao = _conexao.BeginTransaction();

            _conexao.Execute(sqlEmprestimo, new
            {
                IDEmprestimo = emprestimoId,
                DataDevolucaoReal = DateTime.Now
            }, transacao);

            _conexao.Execute(sqlItem, new { IDEmprestimo = emprestimoId }, transacao);

            transacao.Commit();
        }
    }
}
