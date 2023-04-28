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

                // foreach (Actividad actividad in _sistema.Actividades)
                // {
                //       Console.WriteLine(actividad);
                //}

                //  _sistema.ModificarPromocionProveedor("Bacci Tours", 9000);
                // Console.WriteLine(_sistema.ObtenerProveedorPorNombre("Bacci Tours"));


               List<Proveedor> ListaProveedores =  _sistema.ListaProveedoresOrdenada();

                foreach (Proveedor item in ListaProveedores)
                {
                    Console.WriteLine(item);
                }

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

