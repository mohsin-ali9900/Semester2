using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem4.BL
{
    internal class circle : shape
    {
        private double radius;

        public circle(double Radius,string name) : base(name)
        {
            this.radius = Radius;
        }
        public override double getArea()
        {
            return 3.14*radius*radius+base.getArea();
        }
        public override string ToString()
        {
            return " radius : "+radius+base.ToString();
        }
    }
}
