using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using dominio;

namespace DataAccess
{
    public class EmprestimoConfiguration : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.ToTable("Emprestimos");

            builder.HasKey(e => e.IDEmprestimo);

            builder.Property(e => e.DataEmprestimo)
                   .IsRequired();

            builder.Property(e => e.DataDevolucaoPrevista)
                   .IsRequired();

            builder.Property(e => e.DataDevolucaoReal);

            builder.Property(e => e.IDUsuario)
                   .IsRequired();

            builder.Property(e => e.IDItem)
                   .IsRequired();

            builder.Property(e => e.Devolvido)
                   .HasDefaultValue(false);
        }
    }
}
