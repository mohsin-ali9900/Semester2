using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.UI
{
    internal class MenuUI
    {
        public static void header()
        {
            Console.WriteLine("#################################");
            Console.WriteLine("               UMS               ");
            Console.WriteLine("#################################");
        }
        public static void clearScreen()
        {
            Console.WriteLine("Press Any Key to continue...");
            Console.Clear();
            Console.ReadKey();
        }
        public static int menu()
        {
            header();
            int option;
            Console.WriteLine("1. Add Student.");
            Console.WriteLine("2. Add Degree Program.");
            Console.WriteLine("3. Generate Merit.");
            Console.WriteLine("4. View Registered Students.");
            Console.WriteLine("5. View Students Of Specific Program.");
            Console.WriteLine("6. Register Subjects for Specific Students.");
            Console.WriteLine("7. Calculate Fee For All Registered Students.");
            Console.WriteLine("8. Exit.");
            Console.WriteLine("Enter Option : ");
            option = int.Parse(Console.ReadLine());
            return option;
        }
    }
}
