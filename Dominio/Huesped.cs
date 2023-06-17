
using System;
namespace Dominio
{
    public class Huesped : Usuario, IValidable
    {
        public Documento? Documento { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int? Habitacion { get; }
        public static int UltHabitacion { get; set; } = 1;
        public DateTime FechaNac { get; set; }
        public int? Fidelizacion { get; set; } = 1;

        public Huesped()
        {
        }
        public Huesped(Documento documento, string nombre, string apellido, DateTime fechaNac, string email, string contrasenia) : base(email, contrasenia)
        {
            Documento = documento;
            Nombre = nombre;
            Apellido = apellido;
            Habitacion = UltHabitacion++;
            FechaNac = fechaNac;
            Fidelizacion = 1;
        }

        public override void Validar()
        {
            base.Validar();
            HabitacionValida();
            FidelizacionValida();
            ValidarNombre();
            ValidarApellido();
        }

        private void HabitacionValida()
        {
            if (Habitacion == null) throw new Exception("La habitación no puede ser vacía");
        }

        private void FidelizacionValida()
        {
            if (Fidelizacion < 1 || Fidelizacion > 4) throw new Exception("El número debe ser entre 1 y 4");
        }

        private void ValidarNombre()
        {
            if (!Utilidades.StringValido(Nombre)) throw new Exception("El nombre no puede ser vacío");
        }

        private void ValidarApellido()
        {
            if (!Utilidades.StringValido(Apellido)) throw new Exception("El apellido no puede ser vacío");
        }

        private string AsignarTipoDocumento(int tipoIngresado)
        {
            switch (tipoIngresado)
            {
                case 1:
                    return "CI";
                    break;
                case 2:
                    return "PASAPORTE";
                    break;
                case 3:
                    return "OTROS";
                    break;
                default:
                    throw new Exception("Tipo de documento no válido");
            }
        }

        public int Edad()
        {
            int edad = DateTime.Now.Year - FechaNac.Year;

            if (DateTime.Now.Month > FechaNac.Month)
                edad--;
            else if (DateTime.Now.Month == FechaNac.Month)
            {
                if (DateTime.Now.Day == FechaNac.Day)
                    edad--;
            }
            return edad;
        }

        public override string ToString()
        {
            string respuesta = "";
            respuesta += $"Nombre completo: {Nombre} {Apellido} \n";
            respuesta += $"Documento: {AsignarTipoDocumento(Documento.TipoDocumento)}: {Documento.NumDocumento} \n";
            respuesta += $"Email: {Email} \n";
            respuesta += $"Contraseña: {Contrasenia} \n";
            respuesta += $"Fecha de nacimiento: {FechaNac}  \n";
            respuesta += $"Habitacion: {Habitacion} \n";
            return respuesta;
        }
    }
}

