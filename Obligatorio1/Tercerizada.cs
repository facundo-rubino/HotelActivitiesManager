using System;
namespace Obligatorio1
{
	public class Tercerizada : Actividad
	{
		public Proveedor Proveedor { get; set; }
		public bool Confirmada { get; set; }
		public DateTime FechaConfirmacion { get; set; }

		public Tercerizada()
		{
		}

		public Tercerizada(Proveedor proveedor, bool confirmada, DateTime fechaConfirmacion, string nombre, string descripcion, DateTime fecha, int edadMinima, int costo) : base(nombre, descripcion, fecha, edadMinima, costo)
        {
			Proveedor = proveedor;
			Confirmada = confirmada;
			FechaConfirmacion = fechaConfirmacion;
		}

	}
}

