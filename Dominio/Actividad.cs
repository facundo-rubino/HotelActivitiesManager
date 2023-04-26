using System;
namespace Dominio
{
	public abstract class Actividad : IValidable
	{
		public int? Id { get;}
		public static int? UltimoId { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
		public DateTime? Fecha { get; set; }
		public int? EdadMinima { get; set; }
		public int? Costo { get; set; }
        public int? CantMax { get; set; }

		public Actividad()
		{
			Id = UltimoId++;
		}

        public Actividad(string nombre, string descripcion, DateTime fecha, int edadMinima, int costo, int cantMax)
        {
            Id = UltimoId++;
			Nombre = nombre;
			Descripcion = descripcion;
			Fecha = fecha;
			EdadMinima = edadMinima;
			Costo = costo;
            CantMax = cantMax;
        }

        public virtual void Validar()
        {
			ValidarNombre();
			ValidarDescripcion();
            ValidarFecha();

        }

		private void ValidarNombre()
		{
            if (!Utilidades.StringValido(Nombre))
            {
                throw new Exception("El nombre no puede ser vacío");
            }
			if (Nombre.Length > 25)
			{
                throw new Exception("El nombre no puede ser de más de 25 caracteres");
            }
        }

        private void ValidarDescripcion()
        {
            if (!Utilidades.StringValido(Descripcion)) throw new Exception("La descripción no puede ser vacía");
        }

        private void ValidarFecha()
		{
			if(Fecha < DateTime.Now) throw new Exception("La fecha no puede ser menor a la estipulada");
        }

        public override string ToString()
        {
            string respuesta = base.ToString();
            respuesta += $"Identificador: {Id} \n";
            respuesta += $"Actividad: {Nombre} \n";
            respuesta += $"Actividad: {Descripcion} \n";
            respuesta += $"Fecha: {Fecha} \n";
            respuesta += $"Cantidad Máxima: {CantMax} \n";
            respuesta += $"Edad Mínima: {EdadMinima} \n";

            return respuesta;
        }

    }
}

