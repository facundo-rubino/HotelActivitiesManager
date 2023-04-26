using System;
namespace Dominio
{
	public class Documento
	{
        public string? TipoDocumento { get; set; }
        public string? NumDocumento { get; set; }

        public Documento()
		{
		}

		public Documento(string tipo, string numero)
		{
			TipoDocumento = tipo;
			NumDocumento = numero;
		}

		

	}
}

