using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio;
using Microsoft.Identity.Client;

namespace DataAccess;

//Quando implementar a configuration da identidade ele vai ficar em vermelho, vá na lupinha e implemente a interface
public class AluguelConfiguration : IEntityTypeConfiguration<Aluguel>
{
  public void Configure(EntityTypeBuilder<Aluguel> builder)
  {
    builder.ToTable("Alugueis").HasKey(aluguel => aluguel.IDAluguel);

    builder.Property(aluguel => aluguel.IDAluguel).HasColumnName("IDAluguel");
    builder.Property(aluguel => aluguel.DataAluguel).HasColumnName("DataAluguel").HasColumnType("datetime");
    builder.Property(aluguel => aluguel.DataDevolucao).HasColumnName("DataDevolucao").HasDefaultValueSql("GETDATE()");
    
    // Cliente 1 : N Alugueis
    builder
      .HasOne(aluguel => aluguel.Cliente)
      .WithMany(cliente => cliente.Alugueis)
      .HasForeignKey(aluguel => aluguel.IDCliente);

    // Aluguel 1 : N Jogos
    builder
      .HasMany(aluguel => aluguel.Jogos)
      .WithOne(jogo => jogo.Aluguel)
      .HasForeignKey(jogo => jogo.IDAluguel)
      .OnDelete(DeleteBehavior.SetNull); // mantém os jogos, desvinculando;    
  }
}