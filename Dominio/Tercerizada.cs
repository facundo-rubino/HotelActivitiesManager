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


     
    }
}

