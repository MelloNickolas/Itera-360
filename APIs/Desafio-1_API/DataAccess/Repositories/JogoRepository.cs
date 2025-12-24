using Microsoft.EntityFrameworkCore;
using System.Data;
using Dapper;
using Dominio;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
  public class JogoRepository : IJogoRepository
  {
    private readonly IDbConnection _conexao;

    public JogoRepository(Contexto contexto)
    {
      _conexao = contexto.Database.GetDbConnection();

      if (_conexao.State != ConnectionState.Open)
        _conexao.Open();
    }

    // CREATE
    public int CreateJogo(Jogo jogo)
    {
      const string sql = @"
                INSERT INTO Jogos (Nome, Alugado)
                OUTPUT inserted.IDJogo
                VALUES (@Nome, @Alugado);
            ";

      return _conexao.QuerySingle<int>(sql, jogo);
    }

    // READ
    public IEnumerable<Jogo> Listar()
    {
      const string sql = @"SELECT * FROM Jogos;";
      return _conexao.Query<Jogo>(sql).ToList();
    }

    public Jogo GetJogoByID(int jogoId)
    {
      const string sql = @"
                SELECT * FROM Jogos
                WHERE IDJogo = @IDJogo;
            ";

      return _conexao.QuerySingleOrDefault<Jogo>(sql, new { IDJogo = jogoId });
    }

    // UPDATE
    public void UpdateJogo(Jogo jogo)
    {
      const string sql = @"
                UPDATE Jogos
                SET
                    Nome = @Nome,
                    Alugado = @Alugado
                WHERE IDJogo = @IDJogo;
            ";

      _conexao.Execute(sql, jogo);
    }

    // DELETE
    public void DeleteJogo(int jogoId)
    {
      const string sql = @"
                DELETE FROM Jogos
                WHERE IDJogo = @IDJogo;
            ";

      _conexao.Execute(sql, new { IDJogo = jogoId });
    }

    // AÇÕES ESPECÍFICAS
    public void UpdateJogoToAlugado(int jogoId)
    {
      const string sql = @"
                UPDATE Jogos
                SET Alugado = 1
                WHERE IDJogo = @IDJogo;
            ";

      _conexao.Execute(sql, new { IDJogo = jogoId });
    }

    public void UpdateJogoToDisponivel(int jogoId)
    {
      const string sql = @"
                UPDATE Jogos
                SET Alugado = 0
                WHERE IDJogo = @IDJogo;
            ";

      _conexao.Execute(sql, new { IDJogo = jogoId });
    }
  }
}
