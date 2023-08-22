using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem3.BL
{
    internal class cat:mammal
    {
        public cat(string Name):base(Name)
        {
            
        }
        public override string toString()
        {
            return "cat "+base.toString();
        }
        public override void greets()
        {
            Console.WriteLine("Meow");
        }

    }
}
