using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio;

namespace DataAccess;

//Quando implementar a configuration da identidade ele vai ficar em vermelho, vá na lupinha e implemente a interface
public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{
  public void Configure(EntityTypeBuilder<Pedido> builder)
  {
    builder.ToTable("Pedidos").HasKey(pedido => pedido.Id);

    builder.Property(pedido => pedido.Id).HasColumnName("PedidoID");
    builder.Property(pedido => pedido.Nome).HasColumnName("Nome");
    builder.Property(pedido => pedido.ValorTotal).HasColumnName("ValorTotal").HasPrecision(18, 2);

    //relacionamento do pedido com o cliente
    builder
      .HasOne(pedido => pedido.Cliente)
      .WithMany(cliente => cliente.Pedidos)
      .HasForeignKey(pedido => pedido.ClienteId);
  }
}