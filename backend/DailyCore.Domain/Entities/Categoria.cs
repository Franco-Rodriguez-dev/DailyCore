

using DailyCore.Domain.Enums;

namespace DailyCore.Domain.Entities
{
    public class Categoria
    {
        public int Id { get; private set; }

        public string Nombre { get; private set; }

        public TipoCategoria Tipo { get; private set; }

        public int EmpresaId { get; private set; }

        public Empresa Empresa { get; private set; } = null!;

        public bool Activo { get; private set; }

        public DateTime CreatedAt { get; private set; }

        private Categoria ()
        {
            Nombre = string.Empty;

        }

        public Categoria ( string nombre , int empresaId , TipoCategoria tipo)
        {
            if (empresaId <= 0)
                throw new ArgumentException("La empresa es obligatoria.");

            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre es obligatorio.");

            EmpresaId = empresaId;
            Nombre = nombre.Trim();
            Tipo = tipo;
            Activo = true;
            CreatedAt = DateTime.UtcNow;


        }




    }
}
