using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infobez.Task1
{
    [Serializable]
    public class MyFile
    {
        public string Path { get; set; }

        public long Hash { get; set; }
    }
}
