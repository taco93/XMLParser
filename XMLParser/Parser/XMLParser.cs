using System;

namespace XMLParser
{
    class XMLParser : IParser
    {
        private PersonHandler ph;

        public XMLParser()
        {
            ph = new PersonHandler();
        }

        public void ParseFile(string filename)
        {
            HandleInput(filename);
            HandleOutput();
        }

        private void HandleOutput(string output = "output.xml")
        {
            using (var sw = new StreamWriter(output))
            {
                sw.WriteLine(Constants.XMLVersion);

                sw.WriteLine(Constants.PeopleStart);

                sw.WriteLine(ph.ToString());
                
                sw.WriteLine(Constants.PeopleEnd);
            }
        }

        private void HandleInput(string filename)
        {
            // This ensures release of resource when object goes out of scope
            using (var sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    string? line = sr.ReadLine();

                    // End of the stream
                    if (line == null)
                    {
                        continue;
                    }

                    string[] parts = line.Split('|', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                    // Avoid blankspaces
                    if (parts.Length == 0)
                    {
                        continue;
                    }

                    string command = parts[0];

                    // Identify what task to complete
                    switch (command)
                    {
                        case "P":
                            {
                                ph.AddPerson(parts);
                                break;
                            }
                        case "T":
                            {
                                ph.AddTelephone(parts);
                                break;
                            }
                        case "A":
                            {
                                ph.AddAddress(parts);
                                break;
                            }
                        case "F":
                            {
                                ph.AddFamily(parts);
                                break;
                            }
                        default:
                            {
                                throw new Exception("Invalid input: '" + command + "'. Check input file");
                            }
                    }
                }
            }
        }
    }
}