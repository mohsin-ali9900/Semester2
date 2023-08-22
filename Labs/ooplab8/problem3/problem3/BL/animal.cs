using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem3.BL
{
    internal class animal
    {
        protected string name;
        public animal(string Name)
        {
            this.name = Name;
        }
        public virtual string toString()
        {
            return ("Name : " + name);
        }
        public virtual void greets()
        {
            Console.WriteLine("animal");
        }
    }
}
