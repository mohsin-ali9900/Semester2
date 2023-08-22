using problem4.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem4.UI
{
    internal class rectangleUI
    {
        public static rectangle takeInputForRectangle()
        {
            Console.WriteLine("Enter Height : ");
            double h = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Width : ");
            double w = double.Parse(Console.ReadLine());
            rectangle r = new rectangle(w, h, "Reactangle");
            return r;
        }

    }
}
