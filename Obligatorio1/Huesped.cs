using System;
namespace Obligatorio1
{
	public class Huesped : Usuario
	{
		public Documento Documento { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Habitacion { get; set; }
		public DateTime FechaNac { get; set; }
		public int Fidelizacion { get; set; }

		public Huesped()
		{
		}
        public Huesped(Documento documento, int numDoc, string nombre, string apellido, string habitacion, DateTime fechaNac, int fidelizacion, string email, string contrasenia) : base(email, contrasenia)
        {
			Documento = documento;
			Nombre = nombre;
			Apellido = apellido;
			Habitacion = habitacion;
			FechaNac = fechaNac;
			Fidelizacion = fidelizacion;
        }

		public override void Validar()
		{
            base.Validar();
            HabitacionValida();
			FidelizacionValida();
			ValidarNombre();
			ValidarApellido();
        }

        private void HabitacionValida()
		{
            if (!Utilidades.StringValido(Habitacion))
            {
                throw new Exception("La habitación no puede ser vacía");
            }
        }

        private void FidelizacionValida()
		{
			if (Fidelizacion < 1 || Fidelizacion > 4)
			{
                throw new Exception("El número debe ser entre 1 y 4");
            }
		}

        private void ValidarNombre()
		{
            if (!Utilidades.StringValido(Nombre))
            {
                throw new Exception("El nombre no puede ser vacío");
            }
        }

        private void ValidarApellido()
        {
            if (!Utilidades.StringValido(Apellido))
            {
                throw new Exception("El apellido no puede ser vacío");
            }
        }




    }
}

