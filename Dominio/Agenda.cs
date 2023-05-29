using System;
namespace Dominio
{
    public class Agenda
    {
        public Actividad? Actividad { get; set; }
        public Huesped? Huesped { get; set; }
        public bool? Estado { get; set; }
        public int? CostoFinal { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public Agenda()
        {
        }
        public Agenda(Actividad actividad, Huesped huesped, bool estado, DateTime fecha)
        {
            Actividad = actividad;
            Huesped = huesped;
            Estado = estado;
            CostoFinal = CostoFinal;
            FechaCreacion = fecha;
        }

        public bool AgendaTieneHuesped(Documento documentoIngresado)
        {
            bool tiene = false;
            if (Huesped.Documento == documentoIngresado) tiene = true;
            return tiene;
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

