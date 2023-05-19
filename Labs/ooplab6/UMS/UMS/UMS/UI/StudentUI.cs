using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.BL;
using UMS.DL;

namespace UMS.UI
{
    internal class StudentUI
    {
        public static Student takeInputForStudent()
        {
            List<DegreeProgram> prefrences = new List<DegreeProgram>();
            Console.WriteLine("Enter Student Name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Student Age : ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Fsc Marks : ");
            double FscMarks = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Ecat Marks : ");
            double EcatMarks = double.Parse(Console.ReadLine());
            Console.WriteLine("Available Degree Programs :");
            DegreeProgramUI.viewDegreeProgram();
            Console.WriteLine("How many prefrence you want to enter :");
            int noOfPref = int.Parse(Console.ReadLine());
            for(int i =0; i < noOfPref; i++)
            {
                bool flag = false;
                string degName = Console.ReadLine();
                foreach(var dp in DegreeProgramDL.DPList)
                {
                    if(degName == dp.degreeName && !(prefrences.Contains(dp)))
                    {
                        prefrences.Add(dp);
                        flag = true;
                    }
                }
                if(flag == false)
                {
                    Console.WriteLine("Enter valid Degree Program Name .");
                    i--;
                }
            }
            Student sss = new Student(name, age, FscMarks, EcatMarks, prefrences);
            return sss;
        }
        public static void printStudents()
        {
            foreach(var s in StudentDL.stList)
            {
                if(s.DegreeProgramObject != null)
                {
                    Console.WriteLine(s.name + " got admission " + s.DegreeProgramObject.degreeName);

                }
                else
                {
                    Console.WriteLine(s.name + " did not get admission.");
                }
            }
        }
        public static void calculateFeeForAll()
        {
            foreach(var s in StudentDL.stList)
            {
                if(s.DegreeProgramObject != null)
                {
                    Console.WriteLine(s.name + " has" + s.calculateFee() + " fees.");
                }
            }
        }
        public static void viewStudentInDegree(string degreeName)
        {
            Console.WriteLine("Name\tFsc\tEcat\tAge");
            foreach(var s in StudentDL.stList)
            {
                if(s.DegreeProgramObject != null)
                {
                    if(s.DegreeProgramObject.degreeName == degreeName)
                    {
                        Console.WriteLine(s.name + "\t" + s.FSCMarks + "\t" + s.ECATMarks + "\t" + s.age);
                    }
                }
            }
        }
        public static void viewRegisteredStudents()
        {
            Console.WriteLine("Name\tFsc\tEcat\tAge");
            foreach(var s in StudentDL.stList)
            {
                if(s.DegreeProgramObject != null)
                {
                    Console.WriteLine(s.name + "\t" + s.FSCMarks + "\t" + s.ECATMarks + "\t" + s.age);
                }
            }
        }
    }
}
