using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParser
{
    class Phone
    {
        private string _landline, _mobile;

        public Phone(string[] parts)
        {
            _landline = Constants.NotApplicable;
            _mobile = Constants.NotApplicable;

            try
            {
                _landline = parts[1];
                _mobile = parts[2];
            }
            catch (Exception ex)
            {
                //
            }
        }

        public override string ToString()
        {
            string str = Constants.PhoneStart;

            str += Constants.LandLineStart + _landline + Constants.LandLineEnd;

            str += Constants.MobileStart + _mobile + Constants.MobileEnd;

            str += Constants.PhoneEnd;

            return str;
        }
    }
}
