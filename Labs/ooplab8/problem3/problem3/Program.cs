using problem3.BL;
using problem3.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            cat c1 = animalUI.takeInputForCat();
            animalDL.addInList(c1);
            cat c2 = animalUI.takeInputForCat();
            animalDL.addInList(c2);
            dog d1 = animalUI.takeInputForDog();
            animalDL.addInList(d1);
            dog d2 = animalUI.takeInputForDog();
            animalDL.addInList(d2);

            foreach(var a in animalDL.al)
            {
                Console.WriteLine(a.toString());
                Console.ReadKey();
            }
            foreach(var a in animalDL.al)
            {
                a.greets();
                Console.ReadKey();
            }
        }
    }
}
