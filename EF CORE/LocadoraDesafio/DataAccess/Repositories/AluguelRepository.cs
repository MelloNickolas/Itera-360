using System.Data;
using Dapper;
using Dominio;
using DataAccess;
using Microsoft.EntityFrameworkCore;

public class AluguelRepository : IAluguelRepository
{
  private readonly IDbConnection _conexao;

  public AluguelRepository(Contexto contexto)
  {
    // Reutiliza a conexão do EF Core
    _conexao = contexto.Database.GetDbConnection();
  }

  public int CreateAluguel(Aluguel aluguel)
  {
    const string sql = @"
            INSERT INTO Alugueis (DataAluguel, DataDevolucao, IDCliente)
            OUTPUT inserted.IDAluguel
            VALUES (@DataAluguel, @DataDevolucao, @IDCliente)
        ";

    int idAluguel = _conexao.QuerySingle<int>(sql, aluguel);

    //setando os alugueis na tabela de jogos
    const string sqlAtualizaJogo = @"
                UPDATE Jogos SET IDAluguel = @IDAluguel WHERE IDJogo = @IDJogo
            ";

    foreach (var jogo in aluguel.Jogos)
    {
      _conexao.Execute(sqlAtualizaJogo, new { IDAluguel = idAluguel, IDJogo = jogo.IDJogo });
    }

    return idAluguel;
  }

  public void UpdateAluguel(Aluguel aluguel)
  {
    const string sql = @"
            UPDATE Alugueis
            SET DataAluguel = @DataAluguel,
                DataDevolucao = @DataDevolucao,
                IDCliente = @IDCliente
            WHERE IDAluguel = @IDAluguel
        ";

    _conexao.Execute(sql, aluguel);

    // Remove relacionamento do jogo, estamos excluindo o relacionamento entre o jogo 
    const string sqlRemoveVinculo = @"
    UPDATE Jogos
     SET IDAluguel = NULL 
     WHERE IDAluguel = @IDAluguel";
    _conexao.Execute(sqlRemoveVinculo, new { aluguel.IDAluguel });

    //vamos vincular os jogos
    const string sqlVinculaJogo = @"UPDATE Jogos
     SET IDAluguel = @idAluguel 
     WHERE IDJogo = @IDJogo";
    foreach (var jogo in aluguel.Jogos)
    {
      _conexao.Execute(sqlVinculaJogo, new { idAluguel = aluguel.IDAluguel, IDJogo = jogo.IDJogo });
    }
  }

  public Aluguel GetAluguelByID(int idAluguel)
  {
    const string sqlAluguel = @"
    SELECT * FROM Alugueis 
     WHERE IDAluguel = @idAluguel";
    var aluguel = _conexao.QuerySingleOrDefault<Aluguel>(sqlAluguel, new { IDAluguel = idAluguel });


    const string sqlJogos = @"
    SELECT * FROM Jogos 
      WHERE IDAluguel = @idAluguel";
    aluguel.Jogos = _conexao.Query<Jogo>(sqlJogos, new { IDAluguel = idAluguel }).AsList();

    return aluguel;
  }


  public void DeleteAluguelByID(int idAluguel)
  {
    // Remove vínculo dos jogos
    const string sqlRemoveVinculo = @"
    UPDATE Jogos
     SET IDAluguel = NULL 
     WHERE IDAluguel = @idAluguel";
    _conexao.Execute(sqlRemoveVinculo, new { IDAluguel = idAluguel });

    // Deleta o aluguel
    const string sqlAluguel = @"
    DELETE FROM Alugueis 
      WHERE IDAluguel = @idAluguel";
    _conexao.Execute(sqlAluguel, new { IDAluguel = idAluguel });
  }
}