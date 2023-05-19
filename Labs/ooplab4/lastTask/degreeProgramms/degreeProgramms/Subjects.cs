using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace degreeProgramms
{
    internal class Subjects
    {
        public int subCode;
        public int creditHours;
        public string subjectType;
        public int fees;
        
        public Subjects(int Code, int Hours, string Type,int Fee)
        {
            this.subCode = Code;
            this.creditHours = Hours;
            this.subjectType = Type;
            this.fees = Fee;
        }
        public Subjects()
        {

    }
        }
}
