using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using dominio;

namespace DataAccess
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(u => u.IDUsuario);

            builder.Property(u => u.Nome)
                   .HasColumnName("Nome")
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
