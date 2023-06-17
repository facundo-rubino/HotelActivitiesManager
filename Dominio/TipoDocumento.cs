using System;
namespace Dominio
{
    public class TipoDocumento
    {
        public int? Id { get; }
        public static int? UltimoId { get; set; } = 1;
        public string Tipo { get; set; }

        public TipoDocumento()
        {
            Id = UltimoId++;
        }

        public TipoDocumento(string tipo)
        {
            Id = UltimoId++;
            Tipo = tipo;
        }


    }
}

