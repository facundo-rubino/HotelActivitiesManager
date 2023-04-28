using System.Globalization;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;
using Dominio;

namespace AppConsola
{

    internal class Program
    {
        static private Sistema _sistema = Sistema.Instancia;



        static void Main(string[] args)
        {
            try
            {

                _sistema.Precargar();

                int opcion = 0;

                while (opcion != 6)
                {
                    Console.WriteLine("1 - Listado de Actividades");
                    Console.WriteLine("2 - Listado de Proveedores");
                    Console.WriteLine("3 - Listado de Actividades por costo");
                    Console.WriteLine("4 - Modificar promoción de proveedor");
                    Console.WriteLine("5 - Alta de un huesped");
                    Console.WriteLine("6 - Salir");

                    Console.WriteLine("Seleccione una opción");


                    try
                    {
                        opcion = Int32.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }

                    switch (opcion)
                    {
                        case 1:
                            ListadoActividades();
                            break;
                        case 2:
                            ListadoProveedores();
                            break;
                        case 3:
                            ActividadesPorCosto();
                            break;
                        case 4:
                            ModificarPromocion();
                            break;

                        case 5:
                            AltaHuespedes();
                            break;

                        case 6:
                            break;

                        default:
                            Console.WriteLine("Opción incorrecta");
                            break;
                    }

                    Console.ReadKey();
                    Console.Clear();
                }

                Console.WriteLine("Programa finalizado");

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        private static void ListadoActividades()
        {
            Console.WriteLine("Listado actividades");
            foreach (Actividad actividad in _sistema.Actividades)
            {
                Console.WriteLine(actividad);
            }
        }

        private static void ListadoProveedores()
        {
            Console.WriteLine("Listado actividades");

            List<Proveedor> ListaProveedores = (List<Proveedor>)_sistema.ListaProveedoresOrdenada();

            foreach (Proveedor item in ListaProveedores)
            {
                Console.WriteLine(item);
            }
        }

        private static void ActividadesPorCosto()
        {
            Console.WriteLine("Listado actividades");

            List<Actividad> ListaActividadesPorCosto = (List<Actividad>)_sistema.ListaActividadesPorCosto(new DateTime(2024, 03, 01), new DateTime(2024, 05, 01), 50);


            foreach (Actividad item in ListaActividadesPorCosto)
            {
                Console.WriteLine(item);
            }

        }

        private static void ModificarPromocion()
        {
            Console.WriteLine("Listado actividades");


            _sistema.ModificarPromocionProveedor("Bacci Tours", 9000);
            Console.WriteLine(_sistema.ObtenerProveedorPorNombre("Bacci Tours"));
        }

        private static void AltaHuespedes()
        {
            Console.Clear();

            Console.WriteLine("Registro de huespedes");
            Console.WriteLine("-------");
            Console.WriteLine("Ingrese su nombre");
            string nombre = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Registro de huespedes");
            Console.WriteLine("-------");
            Console.WriteLine("Ingrese su apellido");
            string apellido = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Registro de huespedes");
            Console.WriteLine("-------");
            Console.WriteLine("Ingrese email");
            string email = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Registro de huespedes");
            Console.WriteLine("-------");
            Console.WriteLine("Ingrese contraseña");
            string contrasenia = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Registro de huespedes");
            Console.WriteLine("-------");
            Console.WriteLine("Ingrese el tipo de documento (1: CI, 2: PASAPORTE, 3: OTROS):");
            int tipoDocumento = Int32.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Registro de huespedes");
            Console.WriteLine("-------");
            Console.WriteLine("Ingrese el número de documento sin puntos ni guiones");
            string numDocumento = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Registro de huespedes");
            Console.WriteLine("-------");
            Console.WriteLine("Ingrese habitación deseada (Número)");
            string habitacion = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Registro de huespedes");
            Console.WriteLine("-------");
            Console.WriteLine("Ingrese fecha de nacimiento (ej: 2000-04-28)");
            string fechaCruda = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Registro de huespedes");
            Console.WriteLine("-------");
            DateTime fechaNacimiento = DateTime.Parse(fechaCruda);
            Console.Clear();


            Huesped nuevoHuesped = new Huesped(new Documento(tipoDocumento, numDocumento), nombre, apellido, habitacion, fechaNacimiento, email, contrasenia);
            _sistema.AgregarHuesped(nuevoHuesped);


            Console.WriteLine("Datos del nuevo huesped creado:");
            Console.WriteLine("");
            Console.WriteLine(nuevoHuesped);

            Console.ReadKey();
        }

    }
}

