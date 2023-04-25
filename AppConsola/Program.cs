using Dominio;

namespace AppConsola
{

    internal class Program

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

