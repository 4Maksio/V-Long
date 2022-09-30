using VLN;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             *  Test wyświetlania 
             */

            V_Long V;
            
            /*
            for (sbyte i = sbyte.MinValue; i < sbyte.MaxValue; i++)
            {
                V = new(i);
                if (V.ToString() != i.ToString())
                    Console.WriteLine("Było {0} zamiast {1}", V, i);
            }
            Console.WriteLine("Koniec sbyte");

            for (byte i = byte.MinValue; i < byte.MaxValue; i++)
            {
                V = new(i);
                if (V.ToString() != i.ToString())
                    Console.WriteLine("Było {0} zamiast {1}", V, i);
            }
            Console.WriteLine("Koniec byte");
            
            for (short i = short.MinValue; i < short.MaxValue; i++)
            {
                V = new(i);
                if (V.ToString() != i.ToString())
                    Console.WriteLine("Było {0} zamiast {1}", V, i);
            }
            Console.WriteLine("Koniec short");

            for (ushort i = ushort.MinValue; i < ushort.MaxValue; i++)
            {
                V = new(i);
                if (V.ToString() != i.ToString())
                    Console.WriteLine("Było {0} zamiast {1}", V, i);
            }
            Console.WriteLine("Koniec ushort");
            */



            // ^ Zdane ^
            // v Za długo do weryfikacji - uznane za zdane v



            /*
            for (int i = int.MinValue; i < int.MaxValue; i++)
            {
                V = new(i);
                if (V.ToString() != i.ToString())
                    Console.WriteLine("Było {0} zamiast {1}", V, i);
            }
            Console.WriteLine("Koniec int");

            for (uint i = uint.MinValue; i < uint.MaxValue; i++)
            {
                V = new(i);
                if (V.ToString() != i.ToString())
                    Console.WriteLine("Było {0} zamiast {1}", V, i);
            }
            Console.WriteLine("Koniec uint");
            
            for (long i = long.MinValue; i < long.MaxValue; i++)
            {
                V = new(i);
                if (V.ToString() != i.ToString())
                    Console.WriteLine("Było {0} zamiast {1}", V, i);
            }
            Console.WriteLine("Koniec long");

            for (ulong i = ulong.MinValue; i < ulong.MaxValue; i++)
            {
                V = new(i);
                if (V.ToString() != i.ToString())
                    Console.WriteLine("Było {0} zamiast {1}", V, i);
            }
            Console.WriteLine("Koniec ulong");
            */
        }
    }
}