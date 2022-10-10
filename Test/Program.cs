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

            for (short i = short.MinValue; i < short.MaxValue; i++)
            {
                V = new(i);
                if (!V.Equals(i))
                    Console.WriteLine(i);
            }

            sbyte a1 = 5;
            byte a2 = 5;
            short a3 = 2;
            ushort a4 = 2;
            int a5 = 2;
            uint a6 = 2;
            long a7 = 2;
            ulong a8 = 2;
            nint a9 = 2;
            nuint a10 = 2;
            //string a11 = "2";
            //char a12 = '2';
            //V = new(3);
            Console.WriteLine(V.CompareTo(a1));
            Console.WriteLine(V.CompareTo(a2));
            Console.WriteLine(V.CompareTo(a3));
            Console.WriteLine(V.CompareTo(a4));
            Console.WriteLine(V.CompareTo(a5));
            Console.WriteLine(V.CompareTo(a6));
            Console.WriteLine(V.CompareTo(a7));
            Console.WriteLine(V.CompareTo(a8));
            Console.WriteLine(V.CompareTo(a9));
            Console.WriteLine(V.CompareTo(a10));
            //Console.WriteLine(V.CompareTo(a11));
            //Console.WriteLine(V.CompareTo(a12));
            //Console.WriteLine(V.CompareTo(null));
            */
        }
    }
}