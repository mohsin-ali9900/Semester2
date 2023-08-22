using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem4.BL
{
    internal class shape
    {
        protected string name;

        public shape(string Name)
        {
            this.name = Name;
        }

        public string getName()
        {
            return name;
        }
        public void setName(string Name)
        {
            this.name = Name;
        }
        public virtual double getArea()
        {
            return 0;
        }
    }
}
