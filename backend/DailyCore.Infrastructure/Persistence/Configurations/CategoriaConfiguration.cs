using DailyCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DailyCore.Infrastructure.Persistence.Configurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categorias");

            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Empresa)
                .WithMany()
                .HasForeignKey(c => c.EmpresaId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Tipo)
                .IsRequired();

            builder.Property(c => c.Activo)
                .IsRequired();

            builder.Property(c => c.CreatedAt)
                .IsRequired();

            builder.HasIndex(c => new { c.EmpresaId , c.Nombre })
                .IsUnique();
        }



    }
}
