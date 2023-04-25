using System;
namespace Obligatorio1
{
	public class Proveedor
	{

		public string Nombre { get; set; }
		public string Numero { get; set; }
		public string Direccion { get; set; }
        public decimal Descuento { get; set; }

        public Proveedor()
		{
		}
		public Proveedor(string nombre, string numero, string direccion, decimal descuento)
		{
			Nombre = nombre;
			Numero = numero;
			Direccion = direccion;
            Descuento = descuento;
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

             public override string ToString()
        {

            string respuesta = base.ToString();
            respuesta += $"Nombre: {Nombre} \n";
            respuesta += $"Número: {Numero} \n";
            respuesta += $"Direccion:{Direccion}  \n";
            respuesta += $"Descuento: {Descuento} \n";
         
            return respuesta;
        }
    }

}

