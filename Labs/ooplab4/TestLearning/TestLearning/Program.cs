using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestLearning.BL;

namespace TestLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Student studentobj = new Student();
            studentobj.Name = "Ali";
            studentobj.FscMarks = 300;
            studentobj.Ecat = 300;
            studentobj.Matric = 400;
            studentobj.IsHostel = false;
            studentobj.HomeTown = "Lahore";
*/


            List<Student> studentslist = new List<Student>();

            studentslist.Add(GetStudent());
            studentslist.Add(GetStudent());
            studentslist.Add(GetStudent());
            studentslist.Add(GetStudent());
            studentslist.Add(GetStudent());


            foreach(Student student in studentslist)
            {
                student.DisplayStudent();
            }

            Console.WriteLine(studentslist.Count);

            foreach(Student student in studentslist)
            {
                if(student.CalcualteMerit() > 80)
                {
                    student.DisplayStudent();
                }
            }


        }

        static void RemoveStudentByName(string name, List<Student> list)
        {
            foreach(Student stud in list)
            {
                if(stud.Name == name)
                {
                    list.Remove(stud);
                }
            }
        }

        static Student GetStudent()
        {
            string name = Console.ReadLine();
            string hometwon = Console.ReadLine();
            int fsc = 300;
            int matric = 300;
            int ecat = 340;
            string roll = "1";
            Student student = new Student(name, roll, fsc, matric, ecat, hometwon, true);

            return student;

        }

    }
}
