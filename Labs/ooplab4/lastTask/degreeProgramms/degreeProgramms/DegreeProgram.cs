using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace degreeProgramms
{
    internal class DegreeProgram
    {
        public string degreeTitle;
        public int degreeDuration;
        public int noOfSeats;
        public List<Subjects> sub;

        public DegreeProgram(string Title, int Duration, int Seats, List<Subjects> subjecc)
        {
            this.degreeTitle = Title;
            this.degreeDuration = Duration;
            this.noOfSeats = Seats;
            this.sub = subjecc;
        }
        public DegreeProgram()
        {

        }
        public DegreeProgram(string nameDegree)
        {
            this.degreeTitle = nameDegree;
        }
        public void viewStudentsOfSpecificProgram(List<Student> st, List<DegreeProgram> ddgg,string nameOfDegree)
        {
            for(int i = 0; i < ddgg.Count; i++)
            {
                if(nameOfDegree == ddgg[i].degreeTitle)
                {
                    for(int j = 0; j < st.Count; j++)
                    {
                        for(int k = 0; k < st[j].prefrences.Count; k++)
                        {
                            if (st[j].prefrences[k].degreeTitle == ddgg[i].degreeTitle)
                            {
                                Console.WriteLine("{0}", st[j].name);
                            }
                        }
                    }
                }
            }
        }
    }
}
