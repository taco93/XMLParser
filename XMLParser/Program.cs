using System;

namespace XMLParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";

            if (args.Length > 0)
            {
                filename = args[0];
            }

            Parser p = new Parser(ParseType.XML);

            p.Parse(filename);
        }
    }
}