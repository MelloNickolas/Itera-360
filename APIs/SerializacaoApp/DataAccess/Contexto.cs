using Microsoft.EntityFrameworkCore;
using dominio;

namespace DataAccess
{
  public class Contexto : DbContext
  {
    // ===== DbSets (tabelas no banco) =====
    public DbSet<Item> Itens { get; set; }
    public DbSet<Emprestimo> Emprestimos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    // ===== Configuração de conexão =====
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(
          "Server=DESKTOP-2T4L4UE\\SQLEXPRESS;" +
          "Database=AppSerializacao;" +
          "Trusted_Connection=True;" +
          "TrustServerCertificate=True;"
      );
    }

    // ===== Configuração do modelo =====
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new ItemConfiguration());
      modelBuilder.ApplyConfiguration(new EmprestimoConfiguration());
      modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
    }
  }
}
