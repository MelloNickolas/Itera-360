using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio;

namespace DataAccess;

//Quando implementar a configuration da identidade ele vai ficar em vermelho, vá na lupinha e implemente a interface
public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
  public void Configure(EntityTypeBuilder<Cliente> builder)
  {
    builder.ToTable("Clientes").HasKey(cliente => cliente.IDCliente);

    builder.Property(cliente => cliente.IDCliente).HasColumnName("IDCliente");
    builder.Property(cliente => cliente.Nome).HasColumnName("Nome");
    builder.Property(cliente => cliente.Email).HasColumnName("Email");
    builder.Property(cliente => cliente.Telefone).HasColumnName("Telefone");
    
  }
}