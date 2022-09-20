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
            V_Long v = new(14);
            Console.WriteLine(v);
        }
    }
}