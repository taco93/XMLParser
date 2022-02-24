using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParser
{
    enum State
    {
        PERSON, FAMILY
    }

    class Parser
    {
        private State currentState = State.PERSON;

        public bool ParseFile(string filepath)
        {
            if (!File.Exists(filepath))
            {
                Console.WriteLine("No file at given filepath!");

                return false;
            }

            List<string> list = File.ReadAllLines(filepath).ToList();

            list.Reverse();

            string output = "<people>\n";

            while (list.Count > 0)
            {
                if (list.Last().First() == 'P')
                {
                    StartNewPerson(ref list, ref output);
                }
            }

            output += "</people>";

            File.WriteAllText("output.txt", output);

            return true;
        }

        public void AddPerson(ref string[] data, ref string output)
        {
            output += "  <person>\n";

            for (int i = 1; i < data.Length; i++)
            {
                if (i == 1)
                {
                    output += "    <firstname>" + data[i].ToString() + "</firstname>\n";
                }
                else if (i == 2)
                {
                    output += "    <lastname>" + data[i].ToString() + "</lastname>\n";
                }
            }
        }

        public void StartNewPerson(ref List<string> list, ref string output)
        {
            string[] data = list.Last().Split('|');
            AddPerson(ref data, ref output);
            list.RemoveAt(list.Count - 1);

            char command = ' ';

            while (command != 'P' && list.Count > 0)
            {
                data = list.Last().Split('|');
                command = list.Last().First();

                switch (command)
                {
                    case 'P':
                        {
                            if(currentState == State.FAMILY)
                            {
                                output += "    </family>\n";
                            }
                            currentState = State.PERSON;
                            continue;
                        }
                    case 'A':
                        {
                            AddAddress(ref data, ref output);
                            break;
                        }
                    case 'T':
                        {
                            AddTelephone(ref data, ref output);
                            break;
                        }
                    case 'F':
                        {
                            if(currentState == State.FAMILY)
                            {
                                output += "    </family>\n";
                            }

                            currentState = State.FAMILY;
                            AddFamily(ref data, ref output);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Unknown command {0}", command);
                            break;
                        }
                }

                list.RemoveAt(list.Count - 1);
            }

            if(currentState == State.FAMILY)
            {
                output += "    </family>\n";
            }

            output += "  </person>\n";
        }

        private void AddFamily(ref string[] data, ref string output)
        {
            output += "    <family>\n";

            for(int i = 1; i < data.Length; i++)
            {
                if(i == 1)
                {
                    output += "      <name>" + data[i].ToString() + "</name>\n";
                }
                else if(i == 2)
                {
                    output += "        <born>" + data[i].ToString() + "</born>\n";
                }
            }
        }

        private void AddTelephone(ref string[] data, ref string output)
        {
            if (currentState == State.PERSON)
            {
                output += "    <phone>\n";
                for (int i = 1; i < data.Length; i++)
                {
                    if (i == 1)
                    {
                        output += "      <mobile>" + data[i].ToString() + "</mobile>\n";
                    }
                    else if (i == 2)
                    {
                        output += "      <landline>" + data[i].ToString() + "</landline>\n";
                    }
                }
                output += "    </phone>\n";
            }
            else if (currentState == State.FAMILY)
            {
                output += "      <phone>\n";
                for (int i = 1; i < data.Length; i++)
                {
                    if (i == 1)
                    {
                        output += "        <mobile>" + data[i].ToString() + "</mobile>\n";
                    }
                    else if (i == 2)
                    {
                        output += "        <landline>" + data[i].ToString() + "</landline>\n";
                    }
                }
                output += "      </phone>\n";
            }
        }

        private void AddAddress(ref string[] data, ref string output)
        {
            if (currentState == State.PERSON)
            {
                output += "    <address>\n";
                for (int i = 1; i < data.Length; i++)
                {
                    if (i == 1)
                    {
                        output += "      <street>" + data[i].ToString() + "</street>\n";
                    }
                    else if (i == 2)
                    {
                        output += "      <city>" + data[i].ToString() + "</city>\n";
                    }
                    else if (i == 3)
                    {
                        output += "      <zipcode>" + data[i].ToString() + "</zipcode>\n";
                    }
                }
                output += "    </address>\n";
            }
            else if (currentState == State.FAMILY)
            {
                output += "      <address>\n";
                for (int i = 1; i < data.Length; i++)
                {
                    if (i == 1)
                    {
                        output += "        <street>" + data[i].ToString() + "</street>\n";
                    }
                    else if (i == 2)
                    {
                        output += "        <city>" + data[i].ToString() + "</city>\n";
                    }
                    else if (i == 3)
                    {
                        output += "        <zipcode>" + data[i].ToString() + "</zipcode>\n";
                    }
                }
                output += "      </address>\n";
            }
        }
    }
}
