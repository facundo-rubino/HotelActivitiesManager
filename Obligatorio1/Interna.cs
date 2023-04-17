using System;
namespace Obligatorio1
{
	public class Interna : Actividad
	{
		public string Persona { get; set; }
		public string Lugar { get; set; }
		public bool AireLibre { get; set; }

		public Interna()
		{
		}

        public Interna(string persona, string lugar, bool aireLibre, string nombre, string descripcion, DateTime fecha, int edadMinima, int costo) : base(nombre, descripcion, fecha, edadMinima, costo)
        {
			Persona = persona;
			Lugar = lugar;
			AireLibre = aireLibre;
        }
    }
}

