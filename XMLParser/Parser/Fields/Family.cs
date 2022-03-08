using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParser
{
    class Family
    {
        private List<FamilyMember> _family;

        public Family()
        {
            _family = new List<FamilyMember>();
        }

        public override string ToString()
        {
            string str = "";

            for (int i = 0; i < _family.Count; i++)
            {
                str += _family[i].ToString();
            }

            return str;
        }

        public void Add(string[] parts)
        {
            _family.Add(new FamilyMember(parts));
        }

        public FamilyMember? CurrentMember
        {
            get => (_family != null && _family.Count > 0) ? _family.Last() : null;
        }
    }
}
