namespace Obligatorio1;
class Program
{
    static private Sistema _sistema = new Sistema();

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

