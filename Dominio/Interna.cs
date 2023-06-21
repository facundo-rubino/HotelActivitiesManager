using System;
namespace Dominio
{
    public class Interna : Actividad, IValidable
    {

        public string? Persona { get; set; }
        public string? Lugar { get; set; }
        public bool? AireLibre { get; set; }

        public Interna()
        {
        }

        public Interna(string persona, string lugar, bool aireLibre, string nombre, string descripcion, DateTime fecha, int edadMinima, decimal costo, int cupos) : base(nombre, descripcion, fecha, edadMinima, costo, cupos)
        {
            Persona = persona;
            Lugar = lugar;
            AireLibre = aireLibre;
        }

        public override void Validar()
        {
            base.Validar();
            ValidarNombre();
        }

        private void ValidarNombre()
        {
            if (!Utilidades.StringValido(Nombre)) throw new Exception("El nombre no puede ser vacío");
        }

        public override decimal CalcularCosto(int? fidelizacion)
        {
            decimal costoTotal = Costo;

            switch (fidelizacion)
            {
                case 2:
                    costoTotal -= (costoTotal * 10) / 100;
                    break;
                case 3:
                    costoTotal -= (costoTotal * 15) / 100;
                    break;
                case 4:
                    costoTotal -= (costoTotal * 20) / 100;
                    break;
                default:
                    costoTotal = Costo;
                    break;
            }
            return costoTotal;
        }
    }

}

