using problem2.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem2.UI
{
    internal class staffUI
    {
        public static staff getStaff()
        {
            Console.WriteLine("Enter name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Address : ");
            string address = Console.ReadLine();
            Console.WriteLine("Enter School : ");
            string school = Console.ReadLine();
            Console.WriteLine("Enter Pay : ");
            double pay = double.Parse(Console.ReadLine());
            staff s = new staff(name, address, school, pay);
            return s;
        }
    }
}
