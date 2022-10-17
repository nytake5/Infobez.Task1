using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class Decoder
    {
        public static Dictionary<string, string> symbolsLatin = new Dictionary<string, string>()
        {
            { "a", "а"},
            { "A", "А"},
            { "e", "е"},
            { "E", "Е"},
            { "o", "о"},
            { "O", "О"},
            { "p", "р"},
            { "P", "Р"},
            { "c", "с"},
            { "C", "С"},
            { "y", "у"},
            { "x", "х"},
            { "X", "Х"},
            { "B", "В"},
            { "K", "К"},
            { "T", "Т"}
        };

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


        public static string DecodeMessage(string stegocontainer)
        {
            StringBuilder bytes = new StringBuilder();
            for (int i = 0; i < stegocontainer.Length; i++)
            {
                if (symbols.ContainsKey(stegocontainer[i].ToString()))
                {
                    bytes.Append(0);
                }
                if (symbolsLatin.ContainsKey(stegocontainer[i].ToString()))
                {
                    bytes.Append(1);
                }
            }
            string result = bytes.ToString();
            var stringArray = Enumerable.Range(0, result.Length / 8).Select(i => Convert.ToByte(result.Substring(i * 8, 8), 2)).ToArray();
            return Encoding.UTF8.GetString(stringArray);
        }
    }
}
