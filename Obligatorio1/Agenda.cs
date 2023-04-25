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


		public void calcularCosto()
		{


		}

        public override string ToString()
        {
			 
            string respuesta = base.ToString();
            respuesta += $"Nombre:  \n";
            respuesta += $"Actividad: {Actividad.Nombre} \n";
            respuesta += $"Fecha: {Actividad.Fecha} \n";
            respuesta += $"Lugar:  \n";
            respuesta += $"(todo chequeo si es gratis)Costo: {CostoFinal} \n";
            respuesta += $"Estado {Estado} \n";
            respuesta += $"Actividad {Actividad.Nombre} \n";

            return respuesta;
        }
    }
}

