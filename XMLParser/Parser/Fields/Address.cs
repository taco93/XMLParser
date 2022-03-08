using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParser
{
    class Address
    {
        private string _street;
        private string _city;
        private int _zip;

        public Address(string[] parts)
        {
            _street = Constants.NotApplicable;
            _city = Constants.NotApplicable;
            _zip = -1;

            try
            {
                _street = parts[1];
                _city = parts[2];
                _zip = int.Parse(parts[3]);
            }
            catch (Exception ex)
            {
                // Empty for now
            }
        }

        public override string ToString()
        {
            string str = Constants.AddressStart;

            str += Constants.StreetStart + _street + Constants.StreetEnd;

            str += Constants.CityStart + _city + Constants.CityEnd;

            str += Constants.ZipStart + _zip.ToString() + Constants.ZipEnd;

            str += Constants.AddressEnd;

            return str;
        }
    }
}
