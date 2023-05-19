using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.BL;
using UMS.DL;

namespace UMS.UI
{
    internal class DegreeProgramUI
    {
        public static DegreeProgram takeInputForDegree()
        {
            Console.WriteLine("Enter Degree Name: ");
            string degName = Console.ReadLine();
            Console.WriteLine("Enter Degree Duration : ");
            float degDuration = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Seats Of Degree : ");
            int noOfSeats = int.Parse(Console.ReadLine());

            DegreeProgram dp = new DegreeProgram(degName, degDuration, noOfSeats);
            Console.WriteLine("Enter how many subjects to enter : ");
            int noOfSub = int.Parse(Console.ReadLine());

            for(int i = 0; i < noOfSub; i++)
            {
                // this is done here because we cannot add saperete option for addind subjects.
                Subjects sss = SubjectsUI.takeInputOfSubjects();
                if(dp.AddSubject(sss))
                {
                    if(!(SubjectsDL.subjectsList.Contains(sss)))
                    {
                        SubjectsDL.addSubjectIntoList(sss);
                        //SubjectsDL.storeIntoFile("subject.txt", sss);
                    }
                    Console.WriteLine("Subject Added.");
                }
                else
                {
                    Console.WriteLine("Subject Not Added.");
                    Console.WriteLine("20 credit Hour Exceeded.");
                    i--;
                }
            }
            return dp;
        }
        public static void viewDegreeProgram()
        {
            foreach(var dd in DegreeProgramDL.DPList)
            {
                Console.WriteLine(dd.degreeName);
            }
        }
    }
}
