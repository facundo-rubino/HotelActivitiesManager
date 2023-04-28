using System;
namespace Dominio
{
	public class Tercerizada : Actividad, IValidable
    {
		public Proveedor? Proveedor { get; set; }
		public bool? Confirmada { get; set; }
		public DateTime? FechaConfirmacion { get; set; }

		public Tercerizada()
		{
		}

		public Tercerizada(Proveedor proveedor, bool confirmada, DateTime fechaConfirmacion, string nombre, string descripcion, DateTime fecha, int edadMinima, int costo, int cantMax) : base(nombre, descripcion, fecha, edadMinima, costo, cantMax)
        {
			Proveedor = proveedor;
			Confirmada = confirmada;
			FechaConfirmacion = fechaConfirmacion;
		}

        public override string ToString()
        {
            string actividadConfirmada;
            if ((bool)Confirmada)
            {
                actividadConfirmada = "Si";
            }
            else
            {
                actividadConfirmada = "No";
            }

            string respuesta = base.ToString();
            respuesta += $"Proveedor: {Proveedor} \n";
            respuesta += $"Confirmada: {actividadConfirmada} \n";
            respuesta += $"Fecha de confirmación: {FechaConfirmacion} \n";

            return respuesta;
        }



    }
}

