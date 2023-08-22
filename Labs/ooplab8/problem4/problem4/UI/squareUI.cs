using problem4.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem4.UI
{
    internal class squareUI
    {
        public static square takeInputForSquare()
        {
            Console.WriteLine("Enter Length : ");
            double l = double.Parse(Console.ReadLine());
            square s = new square(l, "Square");
            return s;
        }
    }
}
