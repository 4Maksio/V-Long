using System.Numerics;
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
                Console.Write(a & 1);
                a = (sbyte)(a >> 1);
            }
        }
        static void Main(string[] args)
        {
            /*
            sbyte s1 = -1;
            byte s2 = 2;
            short s3 = -3;
            ushort s4 = 4;
            int s5 = -5;
            uint s6 = 6;
            long s7 = -7;
            ulong s8 = 8;
            nint s9 = -9;
            nuint sa = 10;
            V_Long[] V = { new(), new(s1), new(s2), new(s3), new(s4), new(s5), new(s6), new(s7), new(s8), new(s9), new(sa)};
            foreach (V_Long v in V)
            {
                Console.WriteLine(v);
            }
            */

            BigInteger bigInteger1 = new BigInteger(UInt64.MaxValue);
            BigInteger bigInteger3 = BigInteger.Pow(bigInteger1, int.MaxValue);
            Console.WriteLine(bigInteger3);
        }
    }
}