using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem3.BL
{
    internal class dog:mammal
    {
        public dog(string Name): base(Name)
        {
            
        }
        public override string toString()
        {
            return "Dog"+base.toString();
        }
        public override void greets()
        {
            Console.WriteLine("woof");
        }
    }
}
