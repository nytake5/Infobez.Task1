using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public static class Decoder
    {
        public static string Decode(string text, string key)
        {
            StringBuilder result = new StringBuilder();
            int keyIter = 0;
            foreach (char symbol in text)
            {
                //ci = (pi + ki) mod N, pi - символ исходного
                //ki - символ ключа
                int pi = (int)symbol;
                int ki = (int)key[keyIter];
                int ci = (pi - ki);
                if (ci < 0)
                {
                    ci += (int)char.MaxValue;
                }
                result.Append((char)ci);

                keyIter++;
                if (keyIter >= key.Length)
                {
                    keyIter = 0;
                }
            }
            return result.ToString();
        }
    }
}
