using problem2.DL;
using problem2.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            student s1 = studentUI.getStudent();
            personDL.addInList(s1);
            student s2 = studentUI.getStudent();
            personDL.addInList(s2);
            staff st1 = staffUI.getStaff();
            personDL.addInList(st1);
            staff st2 = staffUI.getStaff();
            personDL.addInList(st2);

            foreach(var p in personDL.pl)
            {
                Console.WriteLine(p.toString());
                Console.ReadKey();
            }
        }
    }
}
