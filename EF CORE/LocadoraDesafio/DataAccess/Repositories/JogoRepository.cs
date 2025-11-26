using Microsoft.EntityFrameworkCore.Infrastructure;  // <-- Necessário para GetDbConnection
using Microsoft.EntityFrameworkCore;                 // <-- Garante acesso ao DatabaseFacade
using System.Data;
using Dapper;
using DataAccess;
using Dominio;

public class JogoRepository : IJogoRepository
{
  private readonly IDbConnection _conexao;

  public JogoRepository(Contexto contexto)
  {
    // Reutiliza a conexão do EF Core
    _conexao = contexto.Database.GetDbConnection();
  }

  public int CreateJogo(Jogo jogo)
  {
    const string sql = @"
            INSERT INTO Jogos (Nome, Genero, Plataforma, Disponibilidade)
            OUTPUT inserted.IDJogo
            VALUES (@Nome, @Genero, @Plataforma, @Disponibilidade)
        ";

    return _conexao.QuerySingle<int>(sql, jogo);
  }

  public void UpdateJogo(Jogo jogo)
  {
    const string sql = @"
            UPDATE Jogos
            SET 
                Nome = @Nome,
                Genero = @Genero,
                Plataforma = @Plataforma,
                Disponibilidade = @Disponibilidade
            WHERE IDJogo = @IDJogo
        ";

    _conexao.Execute(sql, jogo);
  }

  public Jogo GetJogoByID(int idJogo)
  {
    const string sql = @"
            SELECT * FROM Jogos
            WHERE IDJogo = @IDJogo
        ";

    return _conexao.QuerySingleOrDefault<Jogo>(sql, new { IDJogo = idJogo });
  }

  public void DeleteJogoByID(int idJogo)
  {
    const string sql = @"
            Delete FROM Jogos
            WHERE IDJogo = @IDJogo
        ";

    _conexao.Execute(sql, new { IDJogo = idJogo });
  }
}


