using System.Threading.Tasks.Dataflow;
using VLN;

namespace Test
{
    class Program
    {
        public static void Wypisz(sbyte a)
        {
            for (int i = 0; i < 8; i++)
            {
                Console.Write(a&1);
                a = (sbyte)(a >> 1);
            }
        }
        static void Main(string[] args)
        {
            nint tmp = 15;
            Console.WriteLine(tmp.);
        }
    }
}