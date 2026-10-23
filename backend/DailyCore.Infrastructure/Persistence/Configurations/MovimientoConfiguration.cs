using DailyCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyCore.Infrastructure.Persistence.Configurations;

public class MovimientoConfiguration : IEntityTypeConfiguration<Movimiento>
{
    public void Configure(EntityTypeBuilder<Movimiento> builder)
    {
        builder.ToTable("Movimientos");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Fecha)
            .IsRequired();

        builder.Property(m => m.Tipo)
            .IsRequired();

        builder.Property(m => m.Monto)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(m => m.Descripcion)
            .HasMaxLength(200);

        builder.Property(m => m.Activo)
            .IsRequired();

        builder.Property(m => m.CreatedAt)
            .IsRequired();

        builder.HasOne(m => m.Usuario)
            .WithMany()
            .HasForeignKey(m => m.UsuarioId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(m => m.Categoria)
            .WithMany()
            .HasForeignKey(m => m.CategoriaId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(m => m.Empresa)
            .WithMany()
            .HasForeignKey(m => m.EmpresaId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}