using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParser
{
    class FamilyMember
    {
        private string _firstname;
        private int _born;
        private Phone? _phone;
        private List<Address?> _addresses;

        public FamilyMember(string[] parts)
        {
            _phone = null;
            _firstname = Constants.NotApplicable;
            _born = -1;
            _addresses = new List<Address?>();

            try
            {
                _firstname = parts[1];
                _born = int.Parse(parts[2]);
            }
            catch (Exception ex)
            {
                // Empty for now
            }
        }

        public Phone? Phone
        {
            get => _phone;
            set => _phone = value;
        }

        public Address? Address
        {
            get => _addresses.Count > 0 ? _addresses.Last() : null;
            set => _addresses.Add(value);
        }

        public override string ToString()
        {
            string str = Constants.FamilyStart;

            str += Constants.FNameStart + _firstname + Constants.FNameEnd;

            str += Constants.BornStart + _born + Constants.BornEnd;

            if (_phone != null)
            {
                str += _phone.ToString();
            }

            for (int i = 0; i < _addresses.Count; i++)
            {
                str += _addresses[i].ToString();
            }

            str += Constants.FamilyEnd;

            return str;
        }
    }
}