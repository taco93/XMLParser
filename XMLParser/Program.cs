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
                filename = args.First();
            }

            Parser p = new Parser();

            if (p.ParseFile(filename))
            {
                Console.WriteLine("Successfully parsed file!");
            }

            Console.WriteLine("To exit press any key!");
            Console.ReadKey();
        }
    }
}