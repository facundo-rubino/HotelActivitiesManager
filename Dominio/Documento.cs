using System;
namespace Dominio
{
	public class Documento
	{
        public TipoDocumento TipoDocumento { get; set; }
        public string? NumDocumento { get; set; }

        public Documento()
		{
		}

		public Documento(TipoDocumento tipo, string numero)
		{
			TipoDocumento = tipo;
			NumDocumento = numero;
		}

	}
}

