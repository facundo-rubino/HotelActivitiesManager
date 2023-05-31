using System;
namespace Dominio
{
    public abstract class Actividad : IValidable, IComparable<Actividad>, IEquatable<Actividad>
    {
        public int? Id { get; }
        public static int? UltimoId { get; set; } = 1;
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public int? EdadMinima { get; set; }
        public decimal Costo { get; set; }
        public int? Cupos { get; set; }

        public Actividad()
        {
            Id = UltimoId++;
        }

        public Actividad(string nombre, string descripcion, DateTime fecha, int edadMinima, decimal costo, int cupos)
        {
            Id = UltimoId++;
            Nombre = nombre;
            Descripcion = descripcion;
            Fecha = fecha;
            EdadMinima = edadMinima;
            Costo = costo;
            Cupos = cupos;
        }

        public virtual void Validar()
        {
            ValidarNombre();
            ValidarDescripcion();
            ValidarFecha();
        }

        private void ValidarNombre()
        {
            if (!Utilidades.StringValido(Nombre)) throw new Exception("El nombre no puede ser vacío");

            if (Nombre.Length > 60) throw new Exception("El nombre no puede ser de más de 60 caracteres");
        }

        private void ValidarDescripcion()
        {
            if (!Utilidades.StringValido(Descripcion)) throw new Exception("La descripción no puede ser vacía");
        }

        private void ValidarFecha()
        {
            if (Fecha < DateTime.Today) throw new Exception("La fecha no puede ser menor a la de hoy");
        }

        public int CompareTo(Actividad? other)
        {
            if (other == null)
                return 0;
            return (int)(other.Costo - Costo);

        }

        public bool Equals(Actividad? other)
        {
            return other != null && Nombre == other.Nombre;
        }

        public abstract decimal CalcularCosto(int? fidelizacion);

        public override string ToString()
        {
            string respuesta = "-------\n";
            respuesta += $"Identificador: {Id} \n";
            respuesta += $"Actividad: {Nombre} \n";
            respuesta += $"Descripción: {Descripcion} \n";
            respuesta += $"Fecha: {Fecha} \n";
            respuesta += $"Costo: {Costo} \n";
            respuesta += $"Cupos: {Cupos} \n";
            respuesta += $"Edad Mínima: {EdadMinima} \n";
            return respuesta;
        }


    }
}

