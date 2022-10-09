using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace VLN
{
    /// <summary>
    /// Very long integer number
    /// </summary>
    public struct V_Long : IComparable
    {
        /// <summary>
        /// Table of bits with sign on first bit and the rest is writen from last to first.
        /// </summary>
        private bool[] number;
        /// <summary>
        /// Table of tables of chars representing subsequent powers of 2
        /// </summary>
        private static char[][] decim;

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
        /// Crates instance depending on type of argument
        /// </summary>
        /// <param name="obj">obj may be standard integer or other numeric type</param>
        public V_Long(object? obj)
        {
            switch (obj)
            {
                case sbyte:
                    this = new((sbyte)obj);
                    break;
                case byte:
                    this = new((byte)obj);
                    break;
                case short:
                    this = new((short)obj);
                    break;
                case ushort:
                    this = new((ushort)obj);
                    break;
                case int:
                    this = new((int)obj);
                    break;
                case uint:
                    this = new((uint)obj);
                    break;
                case long:
                    this = new((long)obj);
                    break;
                case ulong:
                    this = new((ulong)obj);
                    break;
                case nint:
                    this = new((nint)obj);
                    break;
                case nuint:
                    this = new((nuint)obj);
                    break;
                case float:
                    this = new(Convert.ToInt64((float)obj));
                    break;
                case double:
                    this = new(Convert.ToInt64((double)obj));
                    break;
                case decimal:
                    this = new(Convert.ToInt64((decimal)obj));
                    break;
                case null:
                default:
                    this = new(new[] { true });
                    break;
            }
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
            bool Flag = false;
            number = new bool[8];
            if (Number < 0)
            {
                if (Number == sbyte.MinValue)
                {
                    Flag = true;
                    number = new bool[9];
                }
                else
                {
                    Number = (sbyte)~Number;
                    Number++;
                }
                number[0] = true;
            }
            else
                number[0] = false;
            if (Flag)
            {
                for (int i = 1; i < 8; i++)
                {
                    number[i] = false;
                }
                number[8] = true;
            }
            else
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
            bool Flag = false;
            number = new bool[16];
            if (Number < 0)
            {
                if (Number == short.MinValue)
                {
                    Flag = true;
                    number = new bool[17];
                }
                else
                {
                    Number = (short)~Number;
                    Number++;
                }
                number[0] = true;
            }
            else
                number[0] = false;
            if (Flag)
            {
                for (int i = 1; i < 16; i++)
                {
                    number[i] = false;
                }
                number[16] = true;
            }
            else
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
            bool Flag = false;
            number = new bool[32];
            if (Number < 0)
            {
                if (Number == int.MinValue)
                {
                    Flag = true;
                    number = new bool[33];
                }
                else
                {
                    Number = (int)~Number;
                    Number++;
                }
                number[0] = true;
            }
            else
                number[0] = false;
            if (Flag)
            {
                for (int i = 1; i < 32; i++)
                {
                    number[i] = false;
                }
                number[32] = true;
            }
            else
                for (int i = 1; i < 32; i++)
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
            bool Flag = false;
            number = new bool[64];
            if (Number < 0)
            {
                if (Number == long.MinValue)
                {
                    Flag = true;
                    number = new bool[65];
                }
                else
                {
                    Number = ~Number;
                    Number++;
                }
                number[0] = true;
            }
            else
                number[0] = false;
            if (Flag)
            {
                for (int i = 1; i < 64; i++)
                {
                    number[i] = false;
                }
                number[64] = true;
            }
            else
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
            if (decim.Length < number.Length - 1)
            {
                int tmp = decim.Length - 1;
                Array.Resize(ref decim, number.Length - 1);
                if (tmp == 0)
                {
                    decim[0] = new[] { '1' };
                    tmp = 1;
                }
                while (tmp < number.Length-1)
                {
                    decim[tmp] = sum(decim[tmp - 1], decim[tmp - 1]);
                    tmp++;
                }
            }
        }
        /// <summary>
        /// Returns unity digit from sum of digits in chars
        /// </summary>
        /// <param name="a">first digit</param>
        /// <param name="b">second digit</param>
        /// <returns>Unit of sum of digits</returns>
        private char addDecimal(char a, char b)
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
        private char[] sum(char[] A, char[] B)
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
                    chars[i] = addDecimal(chars[i], A[i - (chars.Length - A.Length)]);
                if (B.Length >= chars.Length - i)
                    chars[i] = addDecimal(chars[i], B[i - (chars.Length - B.Length)]);
                if (A.Length >= chars.Length - i && B.Length >= chars.Length - i)
                {
                    tmp = addDecimal(A[i - (chars.Length - A.Length)], B[i - (chars.Length - B.Length)]);
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
            c[idx - 1] = addDecimal(c[idx - 1], '1');
            if (c[idx - 1] == '0')
                overflow(ref c, idx - 1);
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
        /// Checks if object can be converted into V_Long
        /// </summary>
        /// <param name="obj">Object for beeing checked</param>
        /// <returns>True for any basic numeric type</returns>
        public static bool IsOperatable(object? obj)
        {
            switch (obj)
            {
                case V_Long:
                case sbyte:
                case byte:
                case short:
                case ushort:
                case int:
                case uint:
                case long:
                case ulong:
                case nint:
                case nuint:
                case float:
                case double:
                case decimal:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Returns if the instance was created incorrectly
        /// </summary>
        public bool IsNone => number.Length == 1 && number[0] == true;
        /// <summary>
        /// Get length of number in binary
        /// </summary>
        public int Table => number.Length;
        public bool IsPositive => !number[0];

        /// <summary>
        /// Checks equality if o is basic numeric type.
        /// </summary>
        /// <param name="v">V_Long variable</param>
        /// <param name="o">numeric (or not) variable</param>
        /// <returns>Equality for numeric, false for the rest</returns>
        public static bool operator ==(V_Long v, object? o) => v.Equals(o);
        /// <summary>
        /// Checks unequality if o is basic numeric type.
        /// </summary>
        /// <param name="v">V_Long variable</param>
        /// <param name="o">numeric (or not) variable</param>
        /// <returns>Unquality for numeric, true for the rest</returns>
        public static bool operator !=(V_Long v, object? o) => !(v == o);
        /// <summary>
        /// Checks if V_long is greater than object?
        /// </summary>
        /// <param name="v">V_long</param>
        /// <param name="o">Numeric (or not) type</param>
        /// <returns>True if V_Long is greater than object?</returns>
        /// <exception cref="NotNumericExeption">If object isn't basic numeric type</exception>
        public static bool operator >(V_Long v, object? o)
        {
            if (IsOperatable(o))
            {
                V_Long tmp = new(o);
                if (v.Table > tmp.Table && v.IsPositive && tmp.IsPositive || v.Table < tmp.Table && !v.IsPositive && !tmp.IsPositive || v.IsPositive && !tmp.IsPositive)
                    return true;
                if (!v.IsPositive && tmp.IsPositive)
                    return false;
                else if (v.Table == tmp.Table)
                    for (int i = v.Table - 1; i > 0; i--)
                    {
                        if (v.number[i] && !tmp.number[i] && v.IsPositive || !v.number[i] && tmp.number[i] && !v.IsPositive)
                            return true;
                        else if (v.number[i] == tmp.number[i])
                            continue;
                        else
                            break;
                    }
                return false;
            }
            throw new NotNumericExeption();
        }
        /// <summary>
        /// Checks if V_long is smaller than object?
        /// </summary>
        /// <param name="v">V_long</param>
        /// <param name="o">Numeric (or not) type</param>
        /// <returns>True if V_Long is smaller than object?</returns>
        /// <exception cref="NotNumericExeption">If object isn't basic numeric type</exception>
        public static bool operator <(V_Long v, object? o)
        {

            if (IsOperatable(o))
            {
                V_Long tmp = new(o);
                if (v.Table < tmp.Table && v.IsPositive && tmp.IsPositive || v.Table > tmp.Table && !v.IsPositive && !tmp.IsPositive || !v.IsPositive && tmp.IsPositive)
                    return true;
                if (v.IsPositive && !tmp.IsPositive)
                    return false;
                else if (v.Table == tmp.Table)
                    for (int i = v.Table - 1; i > 0; i--)
                    {
                        if (!v.number[i] && tmp.number[i] && v.IsPositive || v.number[i] && !tmp.number[i] && !v.IsPositive)
                            return true;
                        else if (v.number[i] == tmp.number[i])
                            continue;
                        else
                            break;
                    }
                return false;
            }
            throw new NotNumericExeption();
        }
        //  This can be optimized
        /// <summary>
        /// Is v bigger than or equal o
        /// </summary>
        /// <param name="v">V_Long</param>
        /// <param name="o">object?</param>
        /// <returns>True if v is not smaller than o</returns>
        public static bool operator >=(V_Long v, object? o) => v > o || v == o;
        /// <summary>
        /// Is v smaller than or equal o
        /// </summary>
        /// <param name="v">V_Long</param>
        /// <param name="o">object?</param>
        /// <returns>True if v is not bigger than o</returns>
        public static bool operator <=(V_Long v, object? o) => v < o || v == o;

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
                    liczba = sum(liczba, decim[i - 1]);
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
        /// <summary>
        /// Compares object with instance of V_Long
        /// </summary>
        /// <param name="obj">Object representing a number</param>
        /// <returns>True if obj is equal<br/>false otherwise</returns>
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (!IsOperatable(obj))
                return false;
            return Equals(new V_Long(obj));
        }
        /// <summary>
        /// Compares this instance with another V_Long
        /// </summary>
        /// <param name="v">V_Long variable</param>
        /// <returns>True if obj is equal<br/>false otherwise</returns>
        public bool Equals(V_Long v)
        {
            if (Table == v.Table && number[0] == v.number[0])
            {
                for(int i = number.Length-1; i >=0; i--)
                {
                    if (number[i] != v.number[i])
                        return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Compares V-Long with any integer type
        /// </summary>
        /// <param name="obj">Structure beeing Compared to</param>
        /// <returns>1 for obj beeing lower<br/>
        /// 0 for equality<br/>
        /// -1 for obj beeing higher</returns>
        public int CompareTo(object? obj)
        {
            if (IsOperatable(obj))
            {
                if (this == obj)
                    return 0;
                else if (this < obj)
                    return -1;
                else return 1;
            }
            else
                throw new NotNumericExeption();
        }
    }

    /// <summary>
    /// Use this when you can't compare V_Long with another object
    /// </summary>
    public class NotNumericExeption : ArgumentException
    {
        public NotNumericExeption() : base("Tried to compare V-Long with not basic numeric type") { }
    }
}