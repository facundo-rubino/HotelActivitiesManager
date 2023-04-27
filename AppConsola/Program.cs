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

                _sistema.ModificarPromocionProveedor("Bacci Tours", 9000);
                Console.WriteLine(_sistema.ObtenerProveedorPorNombre("Bacci Tours"));    
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

