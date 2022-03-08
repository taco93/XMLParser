using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParser
{
    class Name
    {
        private string _firstname, _lastname;

        public Name(string[] parts)
        {
            _firstname = Constants.NotApplicable;
            _lastname = Constants.NotApplicable;

            try
            {
                _firstname = parts[1];
                _lastname = parts[2];
            }
            catch (Exception ex)
            {
                // Empty for now
            }
        }

        public override string ToString()
        {
            string str = "";

            str += Constants.FirstnameStart + _firstname + Constants.FirstnameEnd;
            str += Constants.LastnameStart + _lastname + Constants.LastnameEnd;

            return str;
        }
    }
}
