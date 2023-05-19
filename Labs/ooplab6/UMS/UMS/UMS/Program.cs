using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.BL;
using UMS.DL;
using UMS.UI;

namespace UMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string SubjectPath = "subject.txt";
            //string StudentPath = "student.txt";
            //string DegreePath = "degree.txt";
            int option;
            do
            {
                option = MenuUI.menu();
                MenuUI.clearScreen();
                if (option == 1)
                {
                    if (DegreeProgramDL.DPList.Count > 0)
                    {
                        Student s = StudentUI.takeInputForStudent();
                        StudentDL.addIntoStudentList(s);
                    }
                }
                else if(option == 2)
                {
                    DegreeProgram dp = DegreeProgramUI.takeInputForDegree();
                    DegreeProgramDL.addIntoDegreeList(dp);
                }
                else if(option == 3)
                {
                    List<Student> sortedStudentList = new List<Student>();
                    sortedStudentList = StudentDL.sortStudentByMerit();
                    StudentDL.giveAdmission(sortedStudentList);
                    StudentUI.printStudents();
                }
                else if(option == 4)
                {
                    StudentUI.viewRegisteredStudents();
                }
                else if(option == 5)
                {
                    Console.WriteLine("Enter Degree Name : ");
                    string degName = Console.ReadLine();
                    StudentUI.viewStudentInDegree(degName);
                }
                else if(option == 6)
                {
                    Console.WriteLine("Enter Student Name : ");
                    string name = Console.ReadLine();
                    Student s = StudentDL.studentPresent(name);
                    if(s != null)
                    {
                        SubjectsUI.viewSubjects(s);
                        SubjectsUI.registerSubjects(s);
                    }
                }
                else if(option == 7)
                {
                    StudentUI.calculateFeeForAll();
                }
            }
            while (option != 8);
        }
        //public void storeIntoFile(string path, Subjects s,DegreeProgram d)
        //{
        //    StreamReader f = new StreamReader(path,true);
        //    string record;
        //    if(File.Exists(path))
        //    {
        //        while((record = f.ReadLine()) != null)
        //        {
        //            string[] splittedRecord = record.Split(',');
        //            string name = splittedRecord[0];
        //            int age = int.Parse(splittedRecord[1]);
        //            string[] splittedRecordForSubjects = splittedRecord[2].Split(';');
        //            d.AddSubjects(s);
        //            addIntoDegreeList(d);
        //        }
        //        f.Close();
        //    }
        //}
    }
}
