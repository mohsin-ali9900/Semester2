using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestLearning.BL
{
    public class Student
    {

        public string Name;
        public string Roll;
        public int FscMarks;
        public int Matric;
        public int Ecat;
        public string HomeTown;
        public bool IsHostel;

        public Student(string Name, string roll, int fsc, int matric, int ecat, string hometown, bool ishostel)
        {
            this.Name = Name;
            this.Roll = roll;
            this.FscMarks = fsc;
            this.Matric = matric;
            this.Ecat = ecat;
            this.HomeTown = hometown;
            this.IsHostel = ishostel;
        }

        public int CalcualteMerit()
        {///here we have the implimentation of the alsdkfjlasdkjfalsdkjf
            return 80;
        }

        public void DisplayStudent()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Roll);
            Console.WriteLine(Matric);
            Console.WriteLine(FscMarks);
            Console.WriteLine(Ecat);
            Console.WriteLine("Merite "+ CalcualteMerit());
        }


    }
}
