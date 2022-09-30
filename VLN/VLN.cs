using System.Text;

namespace VLN
{
    /// <summary>
    /// Very long integer number
    /// </summary>
    public struct V_Long
    {
        /// <summary>
        /// Table of bits with sign on first bit and the rest is writen from last to first.
        /// </summary>
        private bool[] number;
        /// <summary>
        /// Table of tables of chars representing subsequent powers of 2
        /// </summary>
        private char[][] decim;

        /// <summary>
        /// For inside methods only
        /// </summary>
        /// <param name="number">Passed table representing number</param>
        private V_Long(bool[] number)
        {
            this.number = number;
            decim = default;
            iniciate();
        }
        /// <summary>
        /// This represents zero or null. Basicly useless.
        /// </summary>
        public V_Long()
        {
            number = new bool[0];
            decim = default;
            iniciate();
        }
        /// <summary>
        /// Gets V_Long from sbyte
        /// </summary>
        /// <param name="Number">Number for convertion</param>
        public V_Long(sbyte Number)
        {
            number = new bool[8];
            if (Number < 0)
            {
                number[0] = true;
                Number = (sbyte)~Number;
                Number++;
            }
            else
                number[0] = false;
            for (int i = 1; i < 8; i++)
            {
                number[i] = iTb((byte)(Number & 1));
                Number >>= 1;
            }
            decim = default;
            iniciate();
        }
        /// <summary>
        /// Gets V_Long from byte
        /// </summary>
        /// <param name="Number">Number for convertion</param>
        public V_Long(byte Number)
        {
            number = new bool[9];
            number[0] = false;
            for (int i = 1; i <= 8; i++)
            {
                number[i] = iTb((byte)(Number & 1));
                Number >>= 1;
            }
            decim = default;
            iniciate();
        }
        /// <summary>
        /// Gets V_Long from short
        /// </summary>
        /// <param name="Number">Number for convertion</param>
        public V_Long(short Number)
        {
            number = new bool[16];
            if (Number < 0)
            {
                number[0] = true;
                Number = (short)~Number;
                Number++;
            }
            else
                number[0] = false;
            for (int i = 1; i < 16; i++)
            {
                number[i] = iTb((byte)(Number & 1));
                Number >>= 1;
            }
            decim = default;
            iniciate();
        }
        /// <summary>
        /// Gets V_Long from ushort
        /// </summary>
        /// <param name="Number">Number for convertion</param>
        public V_Long(ushort Number)
        {
            number = new bool[17];
            number[0] = false;
            for (int i = 1; i <= 16; i++)
            {
                number[i] = iTb((byte)(Number & 1));
                Number >>= 1;
            }
            decim = default;
            iniciate();
        }
        /// <summary>
        /// Gets V_Long from int
        /// </summary>
        /// <param name="Number">Number for convertion</param>
        public V_Long(int Number)
        {
            number = new bool[32];
            if (Number < 0)
            {
                number[0] = true;
                Number = ~Number;
                Number++;
            }
            else
                number[0] = false;
            for (int i = 1; i < 16; i++)
            {
                number[i] = iTb((byte)(Number & 1));
                Number >>= 1;
            }
            decim = default;
            iniciate();
        }
        /// <summary>
        /// Gets V_Long from uint
        /// </summary>
        /// <param name="Number">Number for convertion</param>
        public V_Long(uint Number)
        {
            number = new bool[33];
            number[0] = false;
            for (int i = 1; i <= 32; i++)
            {
                number[i] = iTb((byte)(Number & 1));
                Number >>= 1;
            }
            decim = default;
            iniciate();
        }
        /// <summary>
        /// Gets V_Long from long
        /// </summary>
        /// <param name="Number">Number for convertion</param>
        public V_Long(long Number)
        {
            number = new bool[64];
            if (Number < 0)
            {
                number[0] = true;
                Number = ~Number;
                Number++;
            }
            else
                number[0] = false;
            for (int i = 1; i < 64; i++)
            {
                number[i] = iTb((byte)(Number & 1));
                Number >>= 1;
            }
            decim = default;
            iniciate();
        }
        /// <summary>
        /// Gets V_Long from ulong
        /// </summary>
        /// <param name="Number">Number for convertion</param>
        public V_Long(ulong Number)
        {
            number = new bool[65];
            number[0] = false;
            for (int i = 1; i <= 64; i++)
            {
                number[i] = iTb((byte)(Number & 1));
                Number >>= 1;
            }
            decim = default;
            iniciate();
        }
        /// <summary>
        /// Gets V_Long from nint
        /// </summary>
        /// <param name="Number">Number for convertion</param>
        public V_Long(nint Number)
        {
            if (nint.MaxValue == Int32.MaxValue)
                this = new V_Long((Int32)Number);
            else
                this = new V_Long((Int64)Number);
        }
        /// <summary>
        /// Gets V_Long from nuint
        /// </summary>
        /// <param name="Number">Number for convertion</param>
        public V_Long(nuint Number)
        {
            if (nuint.MaxValue == UInt32.MaxValue)
                this = new V_Long((UInt32)Number);
            else
                this = new V_Long((UInt64)Number);
        }

        //nie znam struktury BigInteger, więc nie implementuję tego konstruktora
        //public V_Long(BigInteger Number) => this = new();

        /// <summary>
        /// Integer to boolean
        /// </summary>
        /// <returns>True for one, false for 0</returns>
        /// <exception cref="ArgumentException">If parameter is neither 1 or 0.</exception>
        private static bool iTb(byte a)
        {
            if (a == 1)
                return true;
            else if (a == 0)
                return false;
            throw new ArgumentException("Wartość konwertowana na bool nie jest binarna");
        }
        /// <summary>
        /// Boolean to integer
        /// </summary>
        /// <returns>1 or 0</returns>
        private byte bTi(bool a) => a ? (byte)1 : (byte)0;
        /// <summary>
        /// Cut unused cells in table with zeros
        /// </summary>
        private void delZeros()
        {
            int index = 0;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                if (number[i])
                {
                    index = i;
                    break;
                }
            }
            bool[] New = new bool[index + 1];
            for (int i = 0; i < New.Length; i++)
            {
                New[i] = number[i];
            }
            number = New;
        }
        /// <summary>
        /// Does things that every constructor should.
        /// </summary>
        private void iniciate()
        {
            delZeros();
            decim = new char[1][];
            decim[0] = new char[1];
            decim[0][0] = '1';
            fillDecim();
        }
        /// <summary>
        /// Fills table decim depending on number length
        /// </summary>
        private void fillDecim()
        {
            if (number.Length < 2)
                return;
            char[][] New = new char[number.Length - 1][];
            New[0] = decim[0];
            for (int i = 1; i < New.Length; i++)
            {
                New[i] = Twice(New[i - 1]);
            }
            decim = New;
        }
        /// <summary>
        /// Returns twice value of char table (digits)
        /// </summary>
        /// <param name="tab">Value in chars</param>
        /// <returns>Table of chars representing twice of value of tab</returns>
        private char[] Twice(char[] tab)
        {
            char[] New;
            if (tab[0] > '0' && tab[0] < '5')
            {
                New = new char[tab.Length];
                for (int i = tab.Length - 1; i >= 0; i--)
                {
                    if (tab[i] >= '5')
                        New[i - 1] = '1';
                    if (New[i] == '1')
                        New[i] = AddDecimal(New[i], AddDecimal(tab[i], tab[i]));
                    else
                        New[i] = AddDecimal(tab[i], tab[i]);
                }
            }
            else
            {
                New = new char[tab.Length + 1];
                for (int i = tab.Length - 1; i >= 0; i--)
                {
                    if (tab[i] >= 5)
                        New[i] = '1';
                    if (New[i + 1] == '1')
                        New[i + 1] = AddDecimal(New[i + 1], AddDecimal(tab[i], tab[i]));
                    else
                        New[i + 1] = AddDecimal(tab[i], tab[i]);
                }
            }
            return New;
        }
        /// <summary>
        /// Returns unity digit from sum of digits in chars
        /// </summary>
        /// <param name="a">first digit</param>
        /// <param name="b">second digit</param>
        /// <returns>Unit of sum of digits</returns>
        private char AddDecimal(char a, char b)
        {
            byte tmp = (byte)(a + b - 2 * '0');
            if (tmp >= 10)
                tmp -= 10;
            return tmp.ToString()[0];
        }
        /// <summary>
        /// Returns sum of digits represented by chars from two char tables
        /// </summary>
        /// <param name="A">first char table</param>
        /// <param name="B">second char table</param>
        /// <returns>Char of digits of sum of tables</returns>
        private char[] Sum(char[] A, char[] B)
        {
            if (A.Length == 0)
                return B;
            if (B.Length == 0)
                return A;
            char tmp;
            char[] chars = new char[Math.Max(A.Length, B.Length) + 1];
            for (int i = 0; i < chars.Length; i++)
                chars[i] = '0';
            for (int i = 1; i < chars.Length; i++)
            {
                if (A.Length >= chars.Length - i)
                    chars[i] = AddDecimal(chars[i], A[i - (chars.Length - A.Length)]);
                if (B.Length >= chars.Length - i)
                    chars[i] = AddDecimal(chars[i], B[i - (chars.Length - B.Length)]);
                if (A.Length >= chars.Length - i && B.Length >= chars.Length - i)
                {
                    tmp = AddDecimal(A[i - (chars.Length - A.Length)], B[i - (chars.Length - B.Length)]);
                    if (tmp < A[i - (chars.Length - A.Length)] && tmp < B[i - (chars.Length - B.Length)])
                        overflow(ref chars, i);
                }
            }
            if (chars[0] == '1')
                return chars;
            char[] ret = new char[chars.Length - 1];
            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = chars[i + 1];
            }
            return ret;
        }
        /// <summary>
        /// Deals with sum results greater than 10
        /// </summary>
        /// <param name="c">Table where overflow occured</param>
        /// <param name="idx">index on witch the overflow occured</param>
        private void overflow(ref char[] c, int idx)
        {
            if (idx == 0)
                throw new Exception("Table not prepared for operation. Overflow occured.");
            c[idx - 1] = AddDecimal(c[idx - 1], '1');
            if (c[idx-1]=='0')
                overflow(ref c, idx-1);
        }
        /// <summary>
        /// Get number wrote binary
        /// </summary>
        /// <returns>String of zeros and ones reprezenting the number</returns>
        public string WriteBinary()
        {
            StringBuilder sb = new StringBuilder();
            foreach (bool b in number)
                sb.Append(bTi(b));
            return sb.ToString();
        }

        /// <summary>
        /// Get length of number in binary
        /// </summary>
        public int Table => number.Length;

        /// <summary>
        /// Returns number in decimal system
        /// </summary>
        public override string ToString()
        {
            if (number.Length < 2)
                return "0";
            char[] liczba = { };
            for (int i = 1; i < number.Length; i++)
            {
                if (number[i])
                    liczba = Sum(liczba, decim[i - 1]);
            }
            StringBuilder sb = new();
            if (number[0])
                sb.Append('-');
            foreach (char c in liczba)
            {
                sb.Append(c);
            }
            return sb.ToString();
        }
    }
}