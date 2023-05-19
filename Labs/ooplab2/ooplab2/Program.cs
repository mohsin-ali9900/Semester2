using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace ooplab2
{
    internal class Program
    {
        class student
        {
            public string sname;
            public int rollno;
            public float percentage;

        }
        static void Main(string[] args)
        {
            //task1();
            //task2();
            task3();
        }

        static void task1()
        {
            student s1 = new student();
            s1.sname = "Mohsin";
            s1.rollno = 193;
            s1.percentage = 95;
            Console.WriteLine("Name : {0} , Roll No : {1} , Percentage : {2}", s1.sname, s1.rollno, s1.percentage);
            Console.ReadKey();
        }
        static void task2()
        {
            student s1 = new student();
            s1.sname = "Mohsin";
            s1.rollno = 193;
            s1.percentage = 95;
            Console.WriteLine("Name : {0} , Roll No : {1} , Percentage : {2}", s1.sname, s1.rollno, s1.percentage);
            student s2 = new student();
            s2.sname = "Ali";
            s2.rollno = 193;
            s2.percentage = 90;
            Console.WriteLine("Name : {0} , Roll No : {1} , Percentage : {2}", s2.sname, s2.rollno, s2.percentage);
            Console.ReadKey();
        }

        //   -----------------------------------   TASK # 3 --------------------------------------
        class students
        {
            public string name;
            public int rollno;
            public float cgpa;
            public char isHostelite;
            public string department;
        }
        static char menu()
        {
            Console.Clear();
            char choice;
            Console.WriteLine("Press 1 for adding student.");
            Console.WriteLine("Press 2 for view students.");
            Console.WriteLine("Press 3 for top three students");
            Console.WriteLine("Press 4 for exit.");
            choice = char.Parse(Console.ReadLine());
            return choice;
        }
        static students addStudent()
        {
            Console.Clear();
            students s1 = new students();
            Console.WriteLine("Enter name of student : ");
            s1.name = Console.ReadLine();
            Console.WriteLine("Enter Roll No of student : ");
            s1.rollno = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter cgpa of student : ");
            s1.cgpa = float.Parse(Console.ReadLine());
            Console.WriteLine("Is Hostellite (y || n) : ");
            s1.isHostelite = char.Parse(Console.ReadLine());
            Console.WriteLine("Enter department of student : ");
            s1.department = Console.ReadLine();
            return s1;
        }
        static void showStudents(students[] ss,int count)
        {
            Console.Clear();
            for(int i = 0;i<count;i++)
            {
                Console.WriteLine("Name : {0} , Roll No : {1} , CGPA : {2} , Is Hostelite : {3} , Department : {4}", ss[i].name, ss[i].rollno, ss[i].cgpa, ss[i].isHostelite, ss[i].department);
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static int largest(students[] ss, int i, int count)
        {
            int index = i;
            float large = ss[i].cgpa;
            for(int x = i; x< count; x++)
            {
                if(large < ss[x].cgpa)
                {
                    large = ss[x].cgpa;
                    index = x;
                }
            }
            return index;
        }
        static void topStudents(students[] ss,int count)
        {
            Console.Clear();
            if(count == 0)
            {
                Console.WriteLine("No Record Found.");
            }
            else if(count == 1)
            {
                showStudents(ss, 1);
            }
            else if (count == 2)
            {
                for(int i = 0; i < 2; i++)
                {
                    int index = largest(ss, i, count);
                    students temp = ss[index];
                    ss[index] = ss[i];
                    ss[i] = temp;
                }
                showStudents(ss, 2);
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    int index = largest(ss, i, count);
                    students temp = ss[index];
                    ss[index] = ss[i];
                    ss[i] = temp;
                }
                showStudents(ss, 3);
            }
            Console.ReadKey();
        }
        
        static void task3()
        {
            students[] sss = new students[10];
            char option;
            int count = 0;
            do
            {
                option = menu();
                if (option == '1')
                {
                    sss[count] = addStudent();
                    count++;
                }
                else if (option == '2')
                {
                    showStudents(sss, count);

                }
                else if (option == '3')
                {
                    topStudents(sss, count);
                }
                else if (option == '4')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input.");
                }
            }
            while (option != '4');
            Console.WriteLine("Press Any Key To Continue.");
            Console.ReadKey();
        }

    }
}
