using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace challenge2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string path = "E:\\oops\\lab1\\challenge2\\signUp.txt";
            int count = 0;
            
            credentials[] array = new credentials[10];
            char option = '0';
            string name, password;
            while(option != '3')
            {
                option = menu();
                if(option == '1')
                {
                    bool flag = false;
                    Console.Clear();
                    Console.WriteLine("Enter usename : ");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter password : ");
                    password = Console.ReadLine();
                    bool check = checkuser(name, password, array,count);
                    if(check == true)
                    {
                        array[count] = signUp(name, password, count);
                        count++;
                        Console.WriteLine("Signed Up Successfully.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Alredy Exists.");
                        Console.ReadKey();
                    }
                }
                else if(option == '2')
                {
                    Console.Clear();
                    Console.WriteLine("Enter username : ");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter password : ");
                    password = Console.ReadLine();
                    bool flag = false;
                    flag = signIn(name,password,array,count);
                    if(flag == true)
                    {
                        Console.WriteLine("Sined In Successfully.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Wrong Credentials.");
                        Console.ReadKey();
                    }
                }
                else if (option == '3')
                {
                    break;
                }
            }
        }
        static bool signIn(string name,string password,credentials[] array,int count)
        {
            bool flag = false;
            for(int i = 0; i < count; i++)
            {
                if(name == array[i].usernaem && password == array[i].password)
                {
                    flag = true;
                }
            }
            return flag;
        }
        static credentials signUp(string name,string password,int count )
        {
           credentials z1 = new credentials();
             
                    z1.usernaem = name;
                    z1.password = password;
                
            
            return z1;
        }
        static char menu()
        {
            Console.Clear();
            char option;
            Console.WriteLine("1. Sign Up .");
            Console.WriteLine("2. Sign In .");
            Console.WriteLine("3. Exit .");
            option = char.Parse(Console.ReadLine());
            return option;
        }
        static bool checkuser(string name, string password, credentials[] array, int count)
        {
            bool flag = true;
            for(int i=0; i<count; i++)
            {
                if(name == array[i].usernaem && password == array[i].password)
                {
                    flag = false;
                }
            }
            return flag;
        }
    }
}
