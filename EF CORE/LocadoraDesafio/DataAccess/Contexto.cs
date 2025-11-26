using Microsoft.EntityFrameworkCore;
using Dominio;

namespace DataAccess;

// Herdar aas propriedades  para se conectar a um banco de dados
public class Contexto : DbContext
{
  // Aqui vamos definir o conjunto de identidades Cliente
  public DbSet<Jogo> Jogos { get; set; }
  public DbSet<Cliente> Clientes { get; set; }
  public DbSet<Aluguel> Alugueis { get; set; }

  // Aqui vamos configurar as opcoes de conexao com o banco de dados
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer("Server=DESKTOP-2T4L4UE\\SQLEXPRESS;Database=LocadoraDesafio;Trusted_Connection=True;TrustServerCertificate=True;");
  }

  // Agora vamos aplicar as configurações da entidade para o modelo do banco de dados.
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new JogoConfiguration());
    modelBuilder.ApplyConfiguration(new ClienteConfiguration());
    modelBuilder.ApplyConfiguration(new AluguelConfiguration());
  }
}