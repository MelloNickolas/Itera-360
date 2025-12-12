using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using dominio;

namespace DataAccess
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Itens");

            builder.HasKey(i => i.IDItem);

            builder.Property(i => i.Nome)
                   .HasColumnName("Nome")
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(i => i.Disponivel)
                   .HasColumnName("Disponivel")
                   .IsRequired()
                   .HasDefaultValue(true);
        }
    }
}
