using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParser
{
    class Person
    {
        string _firstname, _lastname;
        private Phone? _phone;
        private Address? _address;
        private Family? _family;

        public Person(string[] parts)
        {
            _firstname = Constants.NotApplicable;
            _lastname = Constants.NotApplicable;
            _phone = null;
            _address = null;
            _family = null;

            try
            {
                _firstname = parts[1];
                _lastname = parts[2];
            }
            catch (Exception ex)
            {
                // Might be redundant to throw when you catch an exception. This is to make the exception more clear
                throw new Exception("Invalid input: Person requires first and a last name!");
            }
        }

        public Phone? Phone
        {
            get => _phone;
            set => _phone = value;
        }

        public Address? Address
        {
            get => _address;
            set => _address = value;
        }

        public Family? Family
        {
            get => _family;
            set => _family = value;
        }

        public override string ToString()
        {
            string str = Constants.PersonStart;

            str += Constants.FirstnameStart + _firstname + Constants.FirstnameEnd;

            str += Constants.LastnameStart + _lastname + Constants.LastnameEnd;

            if (_phone != null)
            {
                str += _phone.ToString();
            }

            if (_address != null)
            {
                str += _address.ToString();
            }

            if (_family != null)
            {
                str += _family.ToString();
            }

            str += Constants.PersonEnd;

            return str;
        }
    }
}
