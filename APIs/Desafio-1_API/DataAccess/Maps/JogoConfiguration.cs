using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio;

namespace DataAccess
{
  public class JogoConfiguration : IEntityTypeConfiguration<Jogo>
  {
    public void Configure(EntityTypeBuilder<Jogo> builder)
    {
      builder.ToTable("Jogos");

      builder.HasKey(j => j.IDJogo);

      builder.Property(j => j.Nome)
             .IsRequired()
             .HasMaxLength(100);

      builder.Property(j => j.Alugado)
             .IsRequired()
             .HasDefaultValue(false);
    }
  }
}
