using problem4.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem4.DL
{
    internal class shapeDL
    {
        public static List<shape> sl = new List<shape>();

        public static void addInList(shape s)
        {
            sl.Add(s);
        }
    }
}
