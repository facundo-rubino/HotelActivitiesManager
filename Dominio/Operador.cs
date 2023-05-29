using System;
namespace Dominio
{
    public class Operador : Usuario, IValidable
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaIngreso { get; set; }

        public Operador()
        {
        }

        public Operador(string email, string contrasenia, string nombre, string apellido, DateTime fechaIngreso) : base(email, contrasenia)
        {
            Nombre = nombre;
            Apellido = apellido;
            FechaIngreso = fechaIngreso;
        }
    }
}

