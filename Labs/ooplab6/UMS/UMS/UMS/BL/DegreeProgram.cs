using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.BL
{
    internal class DegreeProgram
    {
        public string degreeName;
        public float degreeDuration;
        public List<Subjects> subjects;
        public int seats;

        public DegreeProgram(string degreeNamee,float degreeDurationn,int seatss)
        {
            this.degreeName = degreeNamee;
            this.degreeDuration = degreeDurationn;
            this.seats = seatss;
            subjects = new List<Subjects>();// initialization of list taken above can be written above outside the constructor.
        }

        public bool isSubjectExists(Subjects sub)
        {
            foreach(var s in subjects)
            {
                if(s.code == sub.code)
                {
                    return true;
                }
            }
            return false;
        }
        public int calculateCreditHours()
        {
            int count = 0;
            for(int i = 0; i < subjects.Count; i++)
            {
                count = count + subjects[i].creditHours;
            }
            return count;
        }

        public bool AddSubject(Subjects s)
        {
            int CH = calculateCreditHours();
            if(CH + s.creditHours < 20)
            {
                subjects.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
