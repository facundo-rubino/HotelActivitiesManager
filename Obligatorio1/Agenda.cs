using System;
namespace Obligatorio1
{
	public class Agenda
	{
		public Actividad Actividad { get; set; }
		public Usuario Usuario { get; set; }
		public bool Estado { get; set; }
		public int CostoFinal { get; set; }

		public Agenda()
		{
		}
        public Agenda(Actividad actividad, Usuario usuario, bool estado, int costoFinal)
        {
			Actividad = actividad;
			Usuario = usuario;
			Estado = estado;
			CostoFinal = costoFinal;
        }
    }
}

