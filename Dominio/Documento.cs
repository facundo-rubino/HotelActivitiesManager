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

		public void ValidarCedula()
		{
			if (!CIValidacion.Validate(NumDocumento)) throw new Exception("Cédula inválida");
		}
		

	}
}

