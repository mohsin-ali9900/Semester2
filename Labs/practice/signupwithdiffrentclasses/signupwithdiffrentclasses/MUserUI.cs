using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signupwithdiffrentclasses
{
    internal class MUserUI
    {
        public static int menu()
        {
            Console.Clear();
            Console.WriteLine("1. Sign In.");
            Console.WriteLine("2. Sign Up.");
            Console.WriteLine("3. Exit.");
            int option;
            Console.WriteLine("Enter Option No : ");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        public static MUser takeInput()
        {
            Console.Clear();
            Console.WriteLine("Enter your Name :");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your Password : ");
            string password = Console.ReadLine();
            Console.WriteLine("Enter your Role : ");
            string role = Console.ReadLine();
            MUser user = new MUser(name, password, role);
            return user;
        }
        public static MUser takeInputforSignIn()
        {
            Console.Clear();
            Console.WriteLine("Enter your Name :");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your Password : ");
            string password = Console.ReadLine();
            MUser user = new MUser(name, password);
            return user;
        }
    }
}
