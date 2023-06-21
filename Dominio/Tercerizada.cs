using System;
namespace Dominio
{
    public class Tercerizada : Actividad
    {
        public Proveedor Proveedor { get; set; }
        public bool Confirmada { get; set; }
        public DateTime? FechaConfirmacion { get; set; }

        public Tercerizada()
        {
        }

        public Tercerizada(Proveedor proveedor, bool confirmada, DateTime fechaConfirmacion, string nombre, string descripcion, DateTime fecha, int edadMinima, decimal costo, int cupos) : base(nombre, descripcion, fecha, edadMinima, costo, cupos)
        {
            Proveedor = proveedor;
            Confirmada = confirmada;
            FechaConfirmacion = fechaConfirmacion;
        }

        public override decimal CalcularCosto(int? fidelizacion)
        {
            decimal costoTotal = Costo;

            if (Confirmada)
            {
                costoTotal -= (costoTotal * Proveedor.Descuento) / 100;

            }
            return costoTotal;
        }

        public override string ToString()
        {
            string actividadConfirmada;
            if (Confirmada)
                actividadConfirmada = "Si";
            else
                actividadConfirmada = "No";

            string respuesta = base.ToString();
            respuesta += $"Proveedor: {Proveedor} \n";
            respuesta += $"Confirmada: {actividadConfirmada} \n";
            respuesta += $"Fecha de confirmación: {FechaConfirmacion} \n";
            return respuesta;
        }


    }
}

