using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem1
{
    internal class Cylinder : Circle
    {
        private double  height = 1;

        public Cylinder()
        {

        }
        public Cylinder(double rad):base(rad)
        {

        }
        public Cylinder(int radius,int h): base(radius)
        {
            this.height = h;
        }
        public Cylinder(int radius, int h,string color) : base(radius,color)
        {
            this.height = h;
        }
        public Cylinder(int h)
        {
            this.height = h;
        }
        public void setHeight(double height)
        {
            this.height = height;
        }
        public double getVolume()
        {
            double volume = 3.14 * radius * radius * height;
            return volume;
        }
    }
}
