using System.Collections.Generic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle();
            c1.setRadius(2);
            c1.setColor("yellow");
            Console.WriteLine("Area : "+c1.getArea()+" Color"+c1.getColor());

            Cylinder cyl1 = new Cylinder();
            cyl1.setRadius(2);
            cyl1.setHeight(2);
            Console.WriteLine("Volume : "+cyl1.getVolume()+" Color : "+cyl1.getColor());

            Cylinder cyl2 = new Cylinder(2,3,"yellow");
            Console.WriteLine("Volume of cylinder 2 : "+cyl2.getVolume()+" Color : "+cyl2.getColor());

            List<Cylinder> cl = new List<Cylinder>();
            cl.Add(cyl1);
            cl.Add(cyl2);
        }
    }
}
