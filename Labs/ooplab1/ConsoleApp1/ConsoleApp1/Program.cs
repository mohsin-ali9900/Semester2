using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World");
            //Console.Write("Hello World");
            //Console.ReadKey();
            //task1();
            //task2();
            //task3();
            //task4();
            //task5();
            //task6();
            //task7();
            //task8();
            //task9();
            Console.ReadKey();
        }
        static void task1()
        {
            string variable;
            variable = Console.ReadLine();
            Console.WriteLine("U Forgot it !!! {0}", variable);
            Console.ReadKey();

        }
        static void task2()
        {
            int variable;
            Console.WriteLine("Hey You Type somwthing");
            variable = int.Parse(Console.ReadLine());
            Console.WriteLine("Typed Number is : {0}",variable);
            Console.ReadKey();
        }
        static void task3()
        {
            char variable = 'A';
            Console.WriteLine("Character Is : {0}", variable);
            Console.ReadKey();
        }
        static void task4()
        {
            float variable;
            variable = float.Parse(Console.ReadLine());
            Console.WriteLine("NUMBER IS : {0}", variable);
            Console.ReadKey();

        }
        static void task5()
        {
            int number;
            Console.WriteLine("Write your Numbers : ");
            number = int.Parse(Console.ReadLine());
            if(number > 50)
            {
                Console.WriteLine("You are Passed.");
            }
            else
            {
                Console.WriteLine("You are Failed.");
            }
            Console.ReadKey();
        }
        static void task6()
        {
            int age,machinePrice,toyPrice;
            Console.Write("Enter age of Lily (1 - 77) : ");
            age = int.Parse(Console.ReadLine());
            Console.Write("Enter price of machine (1 - 10000) : ");
            machinePrice = int.Parse(Console.ReadLine());
            Console.Write("Enter price of each toy (0 - 40) : ");
            toyPrice = int.Parse(Console.ReadLine());

            int variable = 0;
            int sum = 0;
            for(int i = 1;i<=age;i++)
            {
                if(i%2 == 0)
                {
                    variable = variable + 10;
                    sum = sum + variable;
                    sum = sum - 1;
                }
                else
                {
                    sum = sum + toyPrice;
                }
                
            }
            int remain;
            remain = sum - machinePrice;
            if (sum >= machinePrice)
            {
                Console.Write("Yes! Reamaing Price is : {0}", remain);
            }
            else
            {
                int remaining;
                remaining = -1 * remain;
                Console.Write("No! Required amount is {0}", remaining);
            }
            Console.ReadKey();
        }
        static void task7()
        {
            int num1;
            int num2;
            Console.Write("Enter First Number : ");
            num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter Second Number : ");
            num2 = int.Parse(Console.ReadLine());
            int result = add(num1, num2);
            Console.WriteLine("Sum is {0}", result);
            Console.ReadKey();
        }
        static int add(int n1, int n2)
        {
            return n1 + n2;
        }
        static void task8()
        {
            string path = "E:\\oops\\lab1\\ConsoleApp1\\write.txt";
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                String record;
                while((record = fileVariable.ReadLine()) != null)
                {
                    Console.WriteLine(record);
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }
        }
        static void task9()
        {
            string path = "E:\\oops\\lab1\\ConsoleApp1\\write.txt";
            StreamWriter fileVariable = new StreamWriter(path,true);
            fileVariable.WriteLine("Hello");
            fileVariable.Flush();
            fileVariable.Close();
        }
    }
}
