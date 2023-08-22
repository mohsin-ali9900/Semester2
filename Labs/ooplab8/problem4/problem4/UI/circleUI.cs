using problem4.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem4.UI
{
    internal class circleUI
    {
        public static circle takeInputForCircle()
        {
            Console.WriteLine("Enter Radius : ");
            double rad = double.Parse(Console.ReadLine());
            circle c = new circle(rad, "Circle");
            return c;
        }
    }
}
