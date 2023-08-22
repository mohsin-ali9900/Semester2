using problem3.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem3
{
    internal class animalUI
    {
        public static cat takeInputForCat()
        {
            Console.WriteLine("Enter Cat Name : ");
            string name = Console.ReadLine();
            cat c = new cat(name);
            return c;
        }
        public static dog takeInputForDog()
        {
            Console.WriteLine("Enter Dog Name : ");
            string name = Console.ReadLine();
            dog d = new dog(name);
            return d;
        }
    }
}
