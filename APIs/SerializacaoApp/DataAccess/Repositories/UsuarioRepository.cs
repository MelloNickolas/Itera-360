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
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly IDbConnection _conexao;

        public UsuarioRepositorio(Contexto contexto)
        {
            _conexao = contexto.Database.GetDbConnection();

            if (_conexao.State != ConnectionState.Open)
                _conexao.Open();
        }

        public int Salvar(Usuario usuario)
        {
            const string sql = @"
                INSERT INTO Usuarios (Nome)
                OUTPUT inserted.IDUsuario
                VALUES (@Nome);
            ";

            return _conexao.QuerySingle<int>(sql, usuario);
        }

        public void Atualizar(Usuario usuario)
        {
            const string sql = @"
                UPDATE Usuarios
                SET Nome = @Nome
                WHERE IDUsuario = @IDUsuario;
            ";

            _conexao.Execute(sql, usuario);
        }

        public Usuario Obter(int usuarioId)
        {
            const string sql = @"
                SELECT * FROM Usuarios
                WHERE IDUsuario = @IDUsuario;
            ";

            return _conexao.QuerySingleOrDefault<Usuario>(sql, new { IDUsuario = usuarioId });
        }

        public Usuario ObterPorNome(string nome)
        {
            const string sql = @"
                SELECT * FROM Usuarios
                WHERE Nome = @Nome;
            ";

            return _conexao.QuerySingleOrDefault<Usuario>(sql, new { Nome = nome });
        }

        public IEnumerable<Usuario> ListarTodos()
        {
            const string sql = @"SELECT * FROM Usuarios;";
            return _conexao.Query<Usuario>(sql).ToList();
        }
    }
}
