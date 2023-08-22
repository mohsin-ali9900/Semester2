using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem4.BL
{
    internal class rectangle : shape
    {
        private double width;
        private double height;

        public rectangle(double Width,double Height,string Name):base(Name)
        {
            this.height = Height;
            this.width = Width;
        }
        public override double getArea()
        {
            return width*height+base.getArea();
        }
        public override string ToString()
        {
            return " Width : "+width+" Height : "+height+base.ToString();
        }
    }
}
