using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.BL
{
    internal class Subjects
    {
        public string code;
        public string type;
        public int creditHours;
        public int subjectFees;

        public Subjects(string codee,string typee,int creditHourss,int subjectFeess)
        {
            this.code = codee;
            this.type = typee;
            this.creditHours = creditHourss;
            this.subjectFees = subjectFeess;
        }
    }
}
