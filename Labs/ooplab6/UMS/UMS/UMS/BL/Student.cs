using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.BL
{
    internal class Student
    {
        public string name;
        public int age;
        public double FSCMarks;
        public double ECATMarks;
        public double merit;
        public List<Subjects> subList = new List<Subjects>();
        public List<DegreeProgram> prefrences = new List<DegreeProgram>();
        public DegreeProgram DegreeProgramObject;//regDegree

        public Student(string Name,int Age,double Fsc,double Ecat, List<DegreeProgram> pref)
        {
            this.name = Name;
            this.age = Age;
            this.FSCMarks = Fsc;
            this.ECATMarks = Ecat;
            this.prefrences = pref;
        }

        public void calculateMerit()
        {
            this.merit = (((FSCMarks / 1100) * 0.45F) + ((ECATMarks / 400) * 0.55F)) * 100;

        }
        public int getCreditHours()
        {
            int count = 0;
            foreach(var c in subList)
            {
                count = count + c.creditHours;
            }
            return count;
        }
        public bool registerStudentSubject( Subjects s)
        {
            int CH = getCreditHours();
            if (DegreeProgramObject != null && DegreeProgramObject.isSubjectExists(s) && CH + s.creditHours <= 9)
            {
                subList.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }

        public float calculateFee()
        {
            float fee = 0;
            if(DegreeProgramObject != null)
            {
                foreach(var d in subList)
                {
                    fee = fee + d.subjectFees;
                }
            }
            return fee;
        }
    }

}
