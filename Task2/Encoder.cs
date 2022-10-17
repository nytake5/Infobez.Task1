using System.Linq;
using System.Text;

namespace Task2
{
    public static class Encoder
    {
        public static Dictionary<string, string> symbols = new Dictionary<string, string>()
        {
            { "а", "a"},
            { "А", "A"},
            { "е", "e"},
            { "Е", "E"},
            { "о", "o"},
            { "О", "O"},
            { "р", "p"},
            { "Р", "P"},
            { "с", "c"},
            { "С", "C"},
            { "у", "y"},
            { "х", "x"},
            { "Х", "X"},
            { "В", "B"},
            { "К", "K"},
            { "Т", "T"}
        };

        public static string EncodeMessage(string container, string message)
        {
            StringBuilder stegocontainer = new StringBuilder(container);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in Encoding.UTF8.GetBytes(message))
                sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));

            string binaryStr = sb.ToString();
            int j = 0;
            for (int i = 0; i < stegocontainer.Length; i++)
            {
                if (binaryStr.Length <= j)
                {
                    break;
                }
                if (symbols.ContainsKey(stegocontainer[i].ToString()))
                {
                    if (binaryStr[j].Equals('1'))
                    {
                        stegocontainer[i] = symbols[container[i].ToString()].ToCharArray().First();
                    }
                    j++;
                }
            }

            return stegocontainer.ToString();
        }
    }
}
