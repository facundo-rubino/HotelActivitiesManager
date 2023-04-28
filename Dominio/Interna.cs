using System;
namespace Dominio
{
	public class Interna : Actividad, IValidable, IEquatable<Interna>
    {
		public string? Persona { get; set; }
		public string? Lugar { get; set; }
		public bool? AireLibre { get; set; }

		public Interna()
		{
		}

        public Interna(string persona, string lugar, bool aireLibre, string nombre, string descripcion, DateTime fecha, int edadMinima, int costo, int cantMax) : base(nombre, descripcion, fecha, edadMinima, costo, cantMax)
        {
			Persona = persona;
			Lugar = lugar;
			AireLibre = aireLibre;
        }

		public override void Validar()
		{
			base.Validar();
			ValidarNombre();
		}

        private void ValidarNombre()
        {
            if (!Utilidades.StringValido(Nombre)) throw new Exception("El nombre no puede ser vacío");
        }

        public bool Equals(Interna? other)
        {
            return other != null && Nombre == other.Nombre;
        }

    }

}

