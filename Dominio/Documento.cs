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
	}
}

