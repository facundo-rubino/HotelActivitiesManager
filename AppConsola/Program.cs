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
                Console.WriteLine("Precarga confirmada");

                int opcion = 0;

                while (opcion != 6)
                {
                    Console.WriteLine("1 - Registro de huespedes");
                    Console.WriteLine();

                    try
                    {
                        opcion = Int32.Parse(Console.ReadLine());


                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }

                    Console.Clear();

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

                        default:
                            break;
                    }


                    Console.WriteLine("Registro de huespedes");
                    Console.WriteLine("-------");
                    Console.WriteLine("Ingrese email");
                    string email = Console.ReadLine();
                    Console.WriteLine("Ingrese contrasenia");
                    string contrasenia = Console.ReadLine();


                }

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
    }
}

