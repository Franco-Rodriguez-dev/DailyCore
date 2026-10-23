using DailyCore.Domain.Enums;

namespace DailyCore.Domain.Entities;

public class Usuario
{
    public int Id { get; private set; }

    public string Nombre { get; private set; }

    public string Email { get; private set; }

    public string PasswordHash { get; private set; }

    public int EmpresaId { get; private set; }

    public Empresa Empresa { get; private set; } = null!;

    public RolTipo Rol { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public bool Activo { get; private set; }

    private Usuario()
    {
        Nombre = string.Empty;
        Email = string.Empty;
        PasswordHash = string.Empty;
    }

    public Usuario(
        int empresaId,
        RolTipo rol ,
        string nombre,
        string email,
        string passwordHash)
    {
        if (empresaId <= 0)
            throw new ArgumentException("La empresa es obligatoria.");

        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre es obligatorio.");

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("El email es obligatorio.");

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("El hash de contraseña es obligatorio.");

        EmpresaId = empresaId;
        Rol = rol;
        Nombre = nombre.Trim();
        Email = email.Trim();
        PasswordHash = passwordHash;

        Activo = true;
        CreatedAt = DateTime.UtcNow;
    }
}
