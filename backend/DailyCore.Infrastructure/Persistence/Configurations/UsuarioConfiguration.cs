
using DailyCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyCore.Infrastructure.Persistence.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(u => u.Id);

            builder.HasOne(u => u.Empresa)
                .WithMany()
                .HasForeignKey(u => u.EmpresaId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Property(u => u.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(u => u.Rol)
                .IsRequired();

            builder.Property(u => u.Activo)
                .IsRequired();

            builder.Property(u => u.CreatedAt)
                .IsRequired();

            builder.HasIndex(u => u.Email)
                .IsUnique();

        }
    }
}
