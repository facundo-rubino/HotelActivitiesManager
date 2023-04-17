using System;
namespace Obligatorio1
{
	public class Proveedor
	{

		public string Nombre { get; set; }
		public string Numero { get; set; }
		public string Direccion { get; set; }

		public Proveedor()
		{
		}
		public Proveedor(string nombre, string numero, string direccion)
		{
			Nombre = nombre;
			Numero = numero;
			Direccion = direccion;
		}

		public void Validar()
		{
			ValidarNombre();
            ValidarNumero();
            ValidarDireccion();
        }

		private void ValidarNombre()
		{
			if (!Utilidades.StringValido(Nombre))
			{
				throw new Exception("El nombre no puede ser vacío");
			}
		}
        private void ValidarNumero()
        {
            if (!Utilidades.StringValido(Numero))
            {
                throw new Exception("El número no puede ser vacío");
            }
        }
        private void ValidarDireccion()
        {
            if (!Utilidades.StringValido(Direccion))
            {
                throw new Exception("La dirección no puede ser vacía");
            }
        }
    }

}

