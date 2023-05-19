using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignIn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            credentials[] customer = new credentials[10];
            string path = "E:\\oops\\lab1\\SignIn\\read.txt";
            //const int size = 10;
            //string[] names = new string[size];
            //string[] passwords = new string[size];
            int Count = 0;
            string name, password;
            string choice = "0";
            while(choice != "3")
            {
            readData(path, ref Count);
                choice = menu();
                if(choice == "1")
                {
                    Console.WriteLine("Enter username : ");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter password : ");
                    password = Console.ReadLine();
                    bool check = SignIn(customer,name, password, ref Count);
                    if (check)
                    {
                        Console.WriteLine("Signed in succesfully");
                        clearScreen();
                    }
                    else
                    {
                        Console.WriteLine("Wrong Credentials!");
                        clearScreen();
                    }
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Enter username : ");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter password : ");
                    password = Console.ReadLine();
                    bool check = SignUp(name, password, customer,ref Count);
                    if (check)
                    {
                        writeData(path, name, password);
                        Console.WriteLine("Signed up successfully....");
                        clearScreen();
                    }
                    else
                    {
                        Console.WriteLine("User already available!");
                        clearScreen();
                    }

                }
                else if (choice == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    clearScreen();
                }
            }
        }
        static string menu()
        {
            string option;
            Console.WriteLine("1. Sign In .");
            Console.WriteLine("2. Sign Up .");
            Console.WriteLine("3. Enter Option");
            option = (Console.ReadLine());
            return option;
        }
        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    comma++;
                }
                else if(comma == field)
                {
                    item = item + record[i];
                }
            }
            return item;
        }
        static bool SignIn(credentials[] customer,string name, string password, ref int count)
        {
            bool flag =  false;
            for (int idx = 0; idx < count; idx++)
            {
                if(name == customer[idx].userName && password == customer[idx].password)
                {
                    flag = true;
                }
            }
            return flag;
        }
        static bool alreadyExistCheck(credentials[] array,string name, string password, ref int count)
        {
            bool flag = true;
            for(int idx = 0; idx < count; idx++)
            {
                if(name == array[idx].userName && password == array[idx].password)
                {
                    flag = false;
                }
            }
            return flag;
        }
        static bool SignUp(string name, string password, credentials[] array,ref int count)
        {
            credentials user = new credentials();
            bool flag = false;
            bool result = alreadyExistCheck(array,name, password, ref count);
            if(result)
            {
                user.userName = name;
                user.password = password;
                array[count] = user;
                count++;
                flag = true;
            }
            return flag;
        }
        static void clearScreen()
        {
            Console.WriteLine("Press Any Key To Continue : ");
            Console.ReadKey();
            Console.Clear();
        }
        static void readData(string path, ref int Count)
        {
            int x = 0;
            credentials[] customer = new credentials[10];
            credentials user = new credentials();
            if(File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while((record = fileVariable.ReadLine()) != null)
                {
                    user.userName = parseData(record, 1);
                    user.password = parseData(record, 2);
                    Count++;
                    if(x>=5)
                    {
                        break;
                    }
                }
                fileVariable.Close();
            }
            else
            {
                Console.Write("Not Exists!");
            }
        }
        static void writeData(string path, string name, string password)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(name + "," + password);
            file.Flush();
            file.Close();
        }
    }
}
