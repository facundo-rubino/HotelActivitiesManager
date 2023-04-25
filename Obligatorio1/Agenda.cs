using System;
namespace Dominio
{
	public class Agenda
	{
		public Actividad Actividad { get; set; }
		public Huesped Huesped { get; set; }
		public bool Estado { get; set; }
		public int CostoFinal { get; set; }

		public Agenda()
		{
		}
        public Agenda(Actividad actividad, Huesped huesped, bool estado)
        {
			Actividad = actividad;
			Huesped = huesped;
			Estado = estado;
			CostoFinal = CostoFinal;
        }


		public void calcularCosto()
		{


		}

        public override string ToString()
        {
			 
            string respuesta = base.ToString();
            respuesta += $"Nombre: {Huesped.Nombre} \n";
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

