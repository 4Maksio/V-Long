using VLN;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  127-138

            /*
             *  Test wyświetlania - nie zdany
             */
            V_Long V;
            for (int i = -4096; i <= 4096; i++)
            {
                V = new(i);
                Console.WriteLine(V);
            }
        }
    }
}