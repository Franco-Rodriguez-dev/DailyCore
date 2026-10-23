using DailyCore.Domain.Enums;

namespace DailyCore.Domain.Entities;

public class Movimiento
{
    public int Id { get; private set; }

    public Categoria Categoria { get; private set; } = null!;

    public int CategoriaId { get; private set; }

    public decimal Monto { get; private set; }

    public DateTime Fecha { get; private set; }

    public string? Descripcion { get; private set; }

    public int EmpresaId { get; private set; }

    public  Empresa Empresa { get; private set; } = null!;

    public Usuario Usuario { get; private set; } = null!;

    public int UsuarioId { get; private set; }

    public TipoMovimiento Tipo { get; private set; }

    public bool Activo { get; private set; }

    public DateTime CreatedAt { get; private set; }

    private Movimiento()
    {
    }

    public Movimiento(
        int categoriaId,
        decimal monto,
        DateTime fecha,
        string? descripcion,
        int empresaId,
        int usuarioId,
        TipoMovimiento tipo)
    {
        if (categoriaId <= 0)
            throw new ArgumentException("La categoría es obligatoria.");

        if (monto <= 0)
            throw new ArgumentException("El monto debe ser mayor que cero.");

        if (empresaId <= 0)
            throw new ArgumentException("La empresa es obligatoria.");

        if (usuarioId <= 0)
            throw new ArgumentException("El usuario es obligatorio.");

        if (!Enum.IsDefined(tipo))
            throw new ArgumentException("El tipo de movimiento no es válido.");

        CategoriaId = categoriaId;
        Monto = monto;
        Fecha = fecha;
        Descripcion = descripcion?.Trim();
        EmpresaId = empresaId;
        UsuarioId = usuarioId;
        Tipo = tipo;

        Activo = true;
        CreatedAt = DateTime.UtcNow;
    }
}