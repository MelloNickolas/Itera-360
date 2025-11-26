using Microsoft.EntityFrameworkCore.Infrastructure;  // <-- Necessário para GetDbConnection
using Microsoft.EntityFrameworkCore;                 // <-- Garante acesso ao DatabaseFacade
using System.Data;
using Dapper;
using DataAccess;
using Dominio;

public class ClienteRepository :IClienteRepository
{
  private readonly IDbConnection _conexao;

  public ClienteRepository(Contexto contexto)
  {
    // Reutiliza a conexão do EF Core
    _conexao = contexto.Database.GetDbConnection();
  }

  public int CreateCliente(Cliente cliente)
  {
    const string sql = @"
            INSERT INTO Clientes (Nome, Email, Telefone)
            OUTPUT inserted.IDCliente
            VALUES (@Nome, @Email, @Telefone)
        ";

    return _conexao.QuerySingle<int>(sql, cliente);
  }

  public void UpdateCliente(Cliente cliente)
  {
    const string sql = @"
            UPDATE Clientes
            SET 
                Nome = @Nome,
                Email = @Email,
                Telefone = @Telefone
            WHERE IDCliente = @IDCliente
        ";

    _conexao.Execute(sql, cliente);
  }

  public Cliente GetClienteByID(int idCliente)
  {
    const string sql = @"
            SELECT * FROM Clientes
            WHERE IDCliente = @IDCliente
        ";

    return _conexao.QuerySingleOrDefault<Cliente>(sql, new { IDCliente = idCliente });
  }

  public void DeleteClienteByID(int idCliente)
  {
    const string sql = @"
            Delete FROM Clientes
            WHERE IDCliente = @IDCliente
        ";

    _conexao.Execute(sql, new { IDCliente = idCliente });
  }
}