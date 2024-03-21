using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chl3
{
    internal class Person
    {
        private string name;
        private string address;
        public Person(string name, string address)
        {
            this.name = name;
            this.address = address;
        }
        public string getName()
        {
            return name;
        }
        public void setName(string val)
        {
            name = val;
        }
        public string getAddress()
        {
            return address;
        }
        public void setAddress(string val)
        {
            address = val;
        }
        public string toString()
        {
            return $"Person[name={name} ,address={address}]";
        }
    }
}
