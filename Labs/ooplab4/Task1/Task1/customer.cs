using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class customer
    {
        public string name;
        public string address;
        public int contact;
        public List<product> products = new List<product>();

        public customer(string Name,string Address, int Contact)
        {
            this.name = Name;
            this.address = Address;
            this.contact = Contact;
        }
        public void assignToList(product obj)
        {
            this.products.Add(obj);
        }

        public List<product> showProducts()
        {
            return products;
        }
        public customer()
        {

        }
    }
}
