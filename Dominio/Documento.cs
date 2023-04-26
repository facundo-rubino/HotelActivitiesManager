using System;
namespace Dominio
{
	public class Documento
	{
        public string? TipoDocumento { get; set; }
        public int? NumDocumento { get; set; }

        public Documento()
		{
		}

		public Documento(string tipo, int numero)
		{
			TipoDocumento = tipo;
			NumDocumento = numero;
		}

		

	}
}

