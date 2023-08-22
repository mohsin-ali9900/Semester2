using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem2.UI
{
    internal class studentUI
    {
        public static student getStudent()
        {
            Console.WriteLine("Enter name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Address : ");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Program : ");
            string program = Console.ReadLine();
            Console.WriteLine("Enter Year : ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Fee : ");
            double fee = double.Parse(Console.ReadLine());
            student s = new student(name, address, program, year, fee);
            return s;
        }
    }
}
