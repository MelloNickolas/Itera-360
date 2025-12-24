using Microsoft.EntityFrameworkCore;
using Dominio;

namespace DataAccess
{
  public class Contexto : DbContext
  {
    // ===== DbSet (tabela Jogos) =====
    public DbSet<Jogo> Jogos { get; set; }

    // ===== Configuração de conexão =====
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(
          "Server=DESKTOP-2T4L4UE\\SQLEXPRESS;" +
          "Database=DesafioJogo;" +
          "Trusted_Connection=True;" +
          "TrustServerCertificate=True;"
      );
    }

    // ===== Configuração do modelo =====
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new JogoConfiguration());
    }
  }
}
