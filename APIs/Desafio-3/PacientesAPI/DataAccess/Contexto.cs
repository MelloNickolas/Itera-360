using Dominio;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;
public class Contexto : DbContext
{

  public DbSet<Paciente> Pacientes { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer(
          "Server=DESKTOP-2T4L4UE\\SQLEXPRESS;" +
          "Database=DesafioPaciente;" +
          "Trusted_Connection=True;" +
          "TrustServerCertificate=True;");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new PacienteConfiguration());
  }
}