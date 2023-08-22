using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem2
{
    internal class person
    {
        protected string name;
        protected string address;

        public person(string Name, string Address)
        {
            this.name = Name;
            this.address = Address;
        }
        public string getName()
        {
            return name;
        }
        public string getAddress()
        {
            return address;
        }
        public void setAddress(string addresss)
        {
            this.address = addresss;
        }
        public virtual string toString()
        {
            return("Name: "+name+" Address: "+address);
        }
    }
}
