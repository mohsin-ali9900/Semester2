using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem4.BL
{
    internal class square : shape
    {
        private double lenght;

        public square(double Length,string Name):base(Name)
        {
            this.lenght = Length;
        }
        public override double getArea()
        {
            return lenght * lenght + base.getArea();
        }
        public override string ToString()
        {
            return " lenght : "+lenght+base.ToString();
        }
    }
}
