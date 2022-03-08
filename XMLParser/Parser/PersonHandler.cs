using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParser
{
    // Stores all persons and handles the logic to add a person into the list
    class PersonHandler
    {
        private List<Person?> persons;

        public PersonHandler()
        {
            persons = new List<Person?>();
        }

        private Person? CurrentPerson
        {
            get => persons.Count > 0 ? persons.Last() : null;
        }

        public void AddPerson(string[] parts)
        {
            Person p = new Person(parts);

            persons.Add(p);
        }

        public void AddTelephone(string[] parts)
        {
            Person? p = CurrentPerson;

            if(p == null)
            {
                throw new Exception("Invalid input: Telephone doesn't belong to an object");
            }

            Phone phone = new Phone(parts);

            if (p.Family == null)
            {
                p.Phone = phone;
            }
            else
            {
                p.Family.CurrentMember.Phone = phone;
            }
        }

        public void AddAddress(string[] parts)
        {
            Person? p = CurrentPerson;

            if (p == null)
            {
                throw new Exception("Invalid input: Address doesn't belong to an object");
            }

            Address a = new Address(parts);

            if (p.Family == null)
            {
                p.Address = a;
            }
            else
            {
                p.Family.CurrentMember.Address = a;
            }
        }

        public void AddFamily(string[] parts)
        {
            Person? p = CurrentPerson;

            if (p == null)
            {
                throw new Exception("Invalid input: Family doesn't belong to an object");
            }

            if(p.Family == null)
            {
                p.Family = new Family();
            }

            p.Family.Add(parts);
        }

        public override string ToString()
        {
            string str = "";

            for (int i = 0; i < persons.Count; i++)
            {
                str += persons[i].ToString();
            }

            return str;
        }
    }
}
