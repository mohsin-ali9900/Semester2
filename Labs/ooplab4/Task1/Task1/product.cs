using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class product
    {
        public string productName;
        public string type;
        public int price;

        public product(string Name, string Type, int Price)
        {
            this.productName = Name;
            this.type = Type;
            this.price = Price;
        }
        public float calculateTax()
        {
            float tax = 0.02F * price; ;
            return tax;
        }
    }
}
