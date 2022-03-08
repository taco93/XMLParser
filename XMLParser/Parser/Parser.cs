using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParser
{
    enum ParseType
    {
        XML
    }

    class Parser
    {
        private IParser _strategy;

        public Parser(ParseType type)
        {
            if (type == ParseType.XML)
            {
                _strategy = new XMLParser();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void Parse(string filename)
        {
            _strategy.ParseFile(filename);

            Console.WriteLine("Parsed " + filename + " successfully");
        }
    }
}
