using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem2.DL
{
    internal class personDL
    {
        public static List<person> pl = new List<person>();

        public static void addInList(person p)
        {
            pl.Add(p);
        }
    }
}
