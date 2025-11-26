using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio;

namespace DataAccess;

//Quando implementar a configuration da identidade ele vai ficar em vermelho, vá na lupinha e implemente a interface
public class JogoConfiguration : IEntityTypeConfiguration<Jogo>
{
  public void Configure(EntityTypeBuilder<Jogo> builder)
  {
    builder.ToTable("Jogos").HasKey(jogo => jogo.IDJogo);

    builder.Property(jogo => jogo.IDJogo).HasColumnName("IDJogo");
    builder.Property(jogo => jogo.Nome).HasColumnName("Nome");
    builder.Property(jogo => jogo.Genero).HasColumnName("Genero");
    builder.Property(jogo => jogo.Plataforma).HasColumnName("Plataforma");
    builder.Property(jogo => jogo.Disponibilidade).HasColumnName("Disponibilidade");

    // Relacionamento Jogo 1 : Aluguel N
    builder.HasOne(jogo => jogo.Aluguel)
       .WithMany(aluguel => aluguel.Jogos)
       .HasForeignKey(jogo => jogo.IDAluguel)
       .OnDelete(DeleteBehavior.SetNull);

  }
}