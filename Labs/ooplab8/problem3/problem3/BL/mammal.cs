using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem3.BL
{
    internal class mammal : animal
    {
        public mammal(string Name) : base(Name)
        {
        }

        public override string toString()
        {
            return "Mammal "+ base.toString();
        }
        public override void greets()
        {
            Console.WriteLine("mammal");
        }
    }
}
