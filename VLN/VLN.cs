using System.Text;

namespace VLN
{
    public struct V_Long
    {
        private bool[] number;

        public V_Long() => number = new bool[0];
        private V_Long(bool[] number)
        {
            this.number = number;
        }
        public V_Long(sbyte Number)
        {
            number = new bool[8];
            if (Number < 0)
            {
                number[0] = true;
            }
            else
                number[0] = false;
            for (int i = 1; i < 8; i++)
            {
                number[i] = iTb(Number & 1);
                Number >>= 1;
            }
            usunZera();
        }

        private bool iTb(int a)
        {
            if (a == 1)
                return true;
            else if (a == 0)
                return false;
            throw new ArgumentException("Wartość konwertowana na bool nie jest binarna");
        }
        private int bTi(bool a) => a ? 1 : 0;
        private void usunZera()
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (bool b in number)
                sb.Append(bTi(b));
            return sb.ToString();
        }
    }
}