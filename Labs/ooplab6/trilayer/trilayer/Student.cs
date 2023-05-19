using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace degreeProgramms
{
    internal class Student
    {
        public string name;
        public int age;
        public int fsc;
        public int ecat;
        public int noOfObs;
        public List<DegreeProgram> prefrences = new List<DegreeProgram>();
        public List<Subjects> subj = new List<Subjects>();
        public double merit;

        public Student(string Name, int Age, int FSC, int ECAT, int NoOFObs, List<DegreeProgram> preff)
        {
            this.name = Name;
            this.age = Age;
            this.fsc = FSC;
            this.ecat = ECAT;
            this.noOfObs = NoOFObs;
            this.prefrences = preff;
        }
        public List<Subjects> AddStudentSubject(List<Student> sttt, List<DegreeProgram> dggg, string nameee)
        {
            foreach (Student sss in sttt)
            {
                if (nameee == sss.name)
                {
                    Console.WriteLine("Enter Subject Code : ");
                    int codeOfSub = int.Parse(Console.ReadLine());
                    for (int i = 0; i < dggg.Count; i++)
                    {
                        for (int j = 0; j < dggg[i].sub.Count; j++)
                        {
                            if (codeOfSub == dggg[i].sub[j].subCode)
                            {
                                subj.Add(dggg[i].sub[j]);
                            }
                        }
                    }
                }
            }
            return subj;
        }

        public int feeCalculation(List<Student> sList)
        {
            int fee = 0;
            foreach (Student s in sList)
            {
                for (int i = 0; i < s.subj.Count; i++)
                {
                    fee = fee + s.subj[i].fees;
                }
            }
            return fee;
        }
        public int index(List<Student> sstt, string nameeeee)
        {
            int iiindex = -1;
            for (int i = 0; i < sstt.Count; i++)
            {
                if (sstt[i].name == nameeeee)
                {
                    iiindex = i;
                }
            }
            return iiindex;
        }
        public Student()
        {
        }
    }
}
