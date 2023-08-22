using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem2
{
    internal class student : person
    {
        private string program;
        private int year;
        private double fee;

        public student(string Name,string Address,string Program,int Year,double Fee):base(Name,Address)
        {
            this.program = Program;
            this.year = Year;
            this.fee = Fee;
        }
        public string getProgram()
        {
            return program;
        }
        public void setProgram(string Program)
        {
            this.program = Program;
        }
        public int getYear()
        {
            return year;
        }
        public void setYear(int Year)
        {
            this.year = Year;
        }
        public double getFee()
        {
            return fee;
        }
        public void setFee(double Fee)
        {
            this.fee = Fee;
        }
        public override string toString()
        {
            return ("Name: "+name+" Address: "+address+" Program: " + program + " Year : " + year + " Fee" + fee);
        }
    }
}

