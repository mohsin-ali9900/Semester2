using problem4.BL;
using problem4.DL;
using problem4.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            rectangle r1 = rectangleUI.takeInputForRectangle();
            shapeDL.addInList(r1);
            circle c1 = circleUI.takeInputForCircle();
            shapeDL.addInList(c1);
            square s1 = squareUI.takeInputForSquare();
            shapeDL.addInList(s1);
            rectangle r2 = rectangleUI.takeInputForRectangle();
            shapeDL.addInList(r2);
            circle c2 = circleUI.takeInputForCircle();
            shapeDL.addInList(c2);

            shapeUI.viewArea();
            Console.ReadKey();
        }
    }
}
