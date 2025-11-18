using Microsoft.EntityFrameworkCore.Infrastructure;  // <-- Necessário para GetDbConnection
using Microsoft.EntityFrameworkCore;                 // <-- Garante acesso ao DatabaseFacade
using System.Data;
using Dapper;
using DataAccess;
using Dominio;

public class ClienteRepositorio
{
    private readonly IDbConnection _conexao;

    public ClienteRepositorio(Contexto contexto)
    {
        // Reutiliza a conexão do EF Core
        _conexao = contexto.Database.GetDbConnection();
    }

    public int Salvar(Cliente cliente)
    {
        const string sql = @"
            INSERT INTO Clientes (Nome, Email, Ativo)
            OUTPUT inserted.ClienteID
            VALUES (@Nome, @Email, @Ativo)
        ";

        return _conexao.QuerySingle<int>(sql, cliente);
    }

    public void Atualizar(Cliente cliente)
    {
        const string sql = @"
            UPDATE Clientes
            SET 
                Nome = @Nome,
                Email = @Email,
                Ativo = @Ativo
            WHERE ClienteID = @Id
        ";

        _conexao.Execute(sql, cliente);
    }

    public Cliente Obter(int clienteId)
    {
        const string sql = @"
            SELECT * FROM Clientes
            WHERE ClienteID = @ClienteID
        ";

        return _conexao.QuerySingleOrDefault<Cliente>(sql, new { ClienteID = clienteId });
    }

    public Cliente ObterPorEmail(string email)
    {
        const string sql = @"
            SELECT * FROM Clientes
            WHERE Email = @Email
        ";

        return _conexao.QuerySingleOrDefault<Cliente>(sql, new { Email = email });
    }

    public IEnumerable<Cliente> Listar(bool ativo)
    {
        const string sql = @"
            SELECT * FROM Clientes
            WHERE Ativo = @Ativo
        ";

        return _conexao.Query<Cliente>(sql, new { Ativo = ativo }).ToList();
    }
}
