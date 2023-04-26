using Dominio;

namespace AppConsola
{

    public class Program

    {

         static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Compila");

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

