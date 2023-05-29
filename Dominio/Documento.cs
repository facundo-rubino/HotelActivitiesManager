using System;
namespace Dominio
{
    public class Documento
    {
        public int TipoDocumento { get; set; }
        public string? NumDocumento { get; set; }

        public Documento()
        {
        }

        public Documento(int tipo, string numero)
        {
            TipoDocumento = tipo;
            NumDocumento = numero;
        }

        public void ValidarCedula()
        {
            if (TipoDocumento == 1)
            {
                if (!CIValidacion.Validate(NumDocumento)) throw new Exception($"La cédula '{NumDocumento}' no es válida");
            }
        }

        public bool Equals(Documento? other)
        {
            return other != null && TipoDocumento == other.TipoDocumento && NumDocumento == other.NumDocumento;
        }
    }
}

