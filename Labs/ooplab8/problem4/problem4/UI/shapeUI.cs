using problem4.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem4.UI
{
    internal class shapeUI
    {
        public static void viewArea()
        {
            foreach(var s in shapeDL.sl)
            {
                Console.WriteLine("The Shape {0} and its area is {1} ",s.getName(),s.getArea());
            }
        }
    }
}
