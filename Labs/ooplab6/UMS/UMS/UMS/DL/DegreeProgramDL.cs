using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.BL;

namespace UMS.DL
{
    internal class DegreeProgramDL
    {
        public static List<DegreeProgram> DPList = new List<DegreeProgram>();
        public static void addIntoDegreeList(DegreeProgram dp)
        {
            DPList.Add(dp);
        }

        public static DegreeProgram isDegreeExists(string degreeName)
        {
            foreach(var d in DPList)
            {
                if(d.degreeName == degreeName)
                {
                    return d;
                }
            }
            return null;
        }
    }
}
