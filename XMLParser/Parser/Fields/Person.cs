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
        private List<FamilyMember>? _family;

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
                // Empty for now
            }
        }

        public void AddFamilyMember(string[] parts)
        {
            if (_family == null)
            {
                _family = new List<FamilyMember>();
            }

            FamilyMember fm = new FamilyMember(parts);
            _family.Add(fm);
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

        public List<FamilyMember>? Family
        {
            get => _family;
        }

        public FamilyMember? FamilyMember
        {
            get => (_family != null && _family.Count > 0) ? _family.Last() : null;
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

            // Check so the person has a family
            if (_family != null)
            {
                for (int i = 0; i < _family.Count; i++)
                {
                    str += _family[i].ToString();
                }
            }

            str += Constants.PersonEnd;

            return str;
        }
    }
}
