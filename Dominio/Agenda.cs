using System;
namespace Dominio
{
    public class Agenda
    {
        public int? Id { get; }
        public static int? UltimoId { get; set; } = 1;
        public Actividad Actividad { get; set; }
        public Huesped Huesped { get; set; }
        public string? Estado { get; set; }
        public decimal? CostoFinal { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Agenda()
        {
            Id = UltimoId++;
        }
        public Agenda(Actividad actividad, Huesped huesped, string estado, decimal costo, DateTime fecha)
        {
            Id = UltimoId++;
            Actividad = actividad;
            Huesped = huesped;
            Estado = estado;
            CostoFinal = costo;
            FechaCreacion = fecha;
        }

        public void Validar()
        {
            ValidarEdad();
            ValidarCupos();
        }

        private void ValidarEdad()
        {
            if (Huesped.Edad() < Actividad.EdadMinima)
                throw new Exception("No tienes la edad requerida para realizar esta actividad");
        }
        private void ValidarCupos()
        {
            if (Actividad.Cupos < 0)
                throw new Exception("No quedan cupos para esta actividad");
        }

        public bool AgendaEntreFechas(DateTime fechaUno, DateTime fechaDos)
        {
            bool esta = false;

            int fechasComparadas = DateTime.Compare(fechaUno, fechaDos);

            if (fechasComparadas > 0)
            {
                //fecha1 más grande que la fecha2;
                DateTime fechaAux = fechaUno;
                fechaUno = fechaDos;
                fechaDos = fechaAux;
            }

            if (FechaCreacion >= fechaUno && FechaCreacion <= fechaDos)
            {
                esta = true;
            }

            return esta;
        }

        public string EstadoAgenda(decimal costoAgenda)
        {
            string estado = "PENDIENTE_PAGO";
            if (costoAgenda == 0) estado = "CONFIRMADA";

            return estado;
        }

        //public int CompareTo(Agenda? other)
        //{
        //    if (other == null)
        //        return 0;
        //    return other.FechaCreacion - FechaCreacion;

        //}

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

