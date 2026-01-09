using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess;

public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
{
  public void Configure(EntityTypeBuilder<Paciente> builder)
  {
    builder.ToTable("Pacientes");

    builder.HasKey(paciente => paciente.IDPaciente);
    builder.Property(paciente => paciente.IDPaciente).UseIdentityColumn();

    builder.Property(paciente => paciente.Nome).IsRequired().HasMaxLength(100);
    builder.Property(paciente => paciente.DataNascimento).IsRequired();
    builder.Property(paciente => paciente.Ativo).IsRequired();
  }
}