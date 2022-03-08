using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParser
{
    interface IParser
    {
        public void ParseFile(string filename);
    }
}
