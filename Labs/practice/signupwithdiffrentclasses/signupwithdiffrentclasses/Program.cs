using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signupwithdiffrentclasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            while( option != 3)
            {
                option = MUserUI.menu();
                if(option == 1) // Sign In
                {
                    MUser use = MUserUI.takeInputforSignIn();
                    if(use != null)
                    {
                        string role = MUserCRUD.getRole(use);
                        if(role == "admin" || role == "customer")
                        {
                            Console.WriteLine("Signed In Successfully.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Wrong Credentials Entered.");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong Credentials.");
                        Console.ReadKey();
                    }
                }
                if(option == 2)// Sign Up
                {
                    MUser uusseerr = MUserUI.takeInput();
                    if(uusseerr != null)
                    {
                        bool check = MUserCRUD.check(uusseerr);
                        if(check == true)
                        {
                            
                            MUserCRUD.storeInList(uusseerr);
                            Console.WriteLine("USer Signed Up Successfully.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("USer Already Exists.");
                            Console.ReadKey();
                        }
                    }

                    else
                    {
                        Console.WriteLine("Wrong Credentials ENtered.");
                        Console.ReadKey();
                    }
                }
                if(option == 3)
                {
                    break;
                }
            }
        }
    }
}
