using DailyCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyCore.Infrastructure.Persistence;

public class DailyCoreDbContext : DbContext
{
    public DailyCoreDbContext(
        DbContextOptions<DailyCoreDbContext> options)
        : base(options)
    {
    }

    public DbSet<Empresa> Empresas => Set<Empresa>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Movimiento> Movimientos => Set<Movimiento>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(DailyCoreDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}