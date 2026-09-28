using System;
using System.Collections.Generic;
using System.Text;

namespace DailyCore.Domain.Entities
{

    public class Empresa
    {
        public int Id { get; private set; }

        public string Nombre { get; private set; }

        public DateTime CreatedAt { get; private set; }

        private Empresa()
        {
            Nombre = string.Empty;
        }

        public Empresa(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException(
                    "El nombre de la empresa es obligatorio.",
                    nameof(nombre));
            }

            Nombre = nombre.Trim();
            CreatedAt = DateTime.UtcNow;
        }

        public void CambiarNombre(string nuevoNombre)
        {
            if (string.IsNullOrWhiteSpace(nuevoNombre))
            {
                throw new ArgumentException(
                    "El nombre de la empresa es obligatorio.",
                    nameof(nuevoNombre));
            }

            Nombre = nuevoNombre.Trim();
        }

    }
}
