using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public static class Encoder
    {
        public static string EncodeText(string text, string key)
        {
            StringBuilder result = new ();
            int keyIter = 0;
            foreach (char symbol in text)
            {
                //ci = (pi + ki) mod N, pi - символ исходного
                //ki - символ ключа
                int pi = (int)symbol;
                int ki = (int)key[keyIter];
                result.Append((char)((pi + ki) % (int)char.MaxValue));

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
