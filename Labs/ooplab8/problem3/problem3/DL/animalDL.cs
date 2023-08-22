using problem3.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem3.DL
{
    internal class animalDL
    {
        public static List<animal> al = new List<animal>();
        
        public static void addInList(animal a)
        {
            al.Add(a);
        }
    }
}
