using System.Numerics;
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
        /// For methods only
        /// </summary>
        /// <param name="number">Passed table representing number</param>
        private V_Long(bool[] number)
        {
            this.number = number;
        }
        public V_Long() => number = new bool[0];
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
            delZeros();
        }
        public V_Long(byte Number)
        {
            number = new bool[9];
            number[0] = false;
            for (int i = 1; i <= 8; i++)
            {
                number[i] = iTb((byte)(Number & 1));
                Number >>= 1;
            }
            delZeros();
        }
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
            delZeros();
        }
        public V_Long(ushort Number)
        {
            number = new bool[17];
            number[0] = false;
            for (int i = 1; i <= 16; i++)
            {
                number[i] = iTb((byte)(Number & 1));
                Number >>= 1;
            }
            delZeros();
        }
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
            delZeros();
        }
        public V_Long(uint Number)
        {
            number = new bool[33];
            number[0] = false;
            for (int i = 1; i <= 32; i++)
            {
                number[i] = iTb((byte)(Number & 1));
                Number >>= 1;
            }
            delZeros();
        }
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
            delZeros();
        }
        public V_Long(ulong Number)
        {
            number = new bool[65];
            number[0] = false;
            for (int i = 1; i <= 64; i++)
            {
                number[i] = iTb((byte)(Number & 1));
                Number >>= 1;
            }
            delZeros();
        }
        public V_Long(nint Number)
        {
            if (nint.MaxValue == Int32.MaxValue)
                this = new V_Long((Int32)Number);
            else
                this = new V_Long((Int64)Number);
        }
        public V_Long(nuint Number)
        {
            if (nuint.MaxValue == UInt32.MaxValue)
                this = new V_Long((UInt32)Number);
            else
                this = new V_Long((UInt64)Number);
        }
        //public V_Long(BigInteger Number) => this = new();

        /// <summary>
        /// Integer to boolean
        /// </summary>
        /// <returns>True for one, false for 0</returns>
        /// <exception cref="ArgumentException">If parameter is neither 1 or 0.</exception>
        private bool iTb(byte a)
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
        /// 
        /// </summary>
        /// <returns>Table of bits</returns>
        public string WriteBinary()
        {
            StringBuilder sb = new StringBuilder();
            foreach (bool b in number)
                sb.Append(bTi(b));
            return sb.ToString();
        }
        /// <summary>
        /// Body for constructors
        /// </summary>
        /// <param name="o">Parameter from constructor</param>
        private void Construct(object o)
        {

        }
    }
}