using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace degreeProgramms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<DegreeProgram> dgList = new List<DegreeProgram>();
            DegreeProgram dg = new DegreeProgram();
            Student std = new Student();
            List<Student> stdList = new List<Student>();
            while (true)
            {
                Console.Clear();
                int option = Menu();
                
                if(option == 2)
                {
                    dg = AddDegreeProgram();
                    dgList.Add(dg);
                    //if(dg != null)
                    //{
                    //    Console.WriteLine("Null Degree");
                    //    Console.ReadKey();
                    //}
                    //foreach (DegreeProgram i in dgList)
                    //{
                    //    Console.WriteLine(i.degreeTitle);
                    //}
                    //    Console.ReadKey();
                    

                }
                else if(option == 1)
                {
                    std = AddStudent(dgList);
                    stdList.Add(std);
                }
                else if(option == 3)
                {
                    generateMerit(stdList);
                    sortByMerit(stdList);
                    setAccordingToPrefrences(stdList,dgList);
                    Console.Clear();
                }
                else if(option == 4)
                {
                    viewRegisteredStudents(stdList);
                }
                else if(option == 5)
                {
                    Console.Clear();
                    Console.WriteLine("Enter Degree Title : ");
                    string degree = Console.ReadLine();
                    dg.viewStudentsOfSpecificProgram(stdList, dgList, degree);
                    Console.ReadKey();

                }
                else if(option == 6)
                {
                    Console.WriteLine("Enter name of Student : ");
                    string nnaammee = Console.ReadLine();
                    int index = std.index(stdList, nnaammee);
                    if(index != -1)
                    {
                        List<Subjects> sbsb = std.AddStudentSubject(stdList, dgList, nnaammee);
                        stdList.Insert(index, std);
                    }


                }
                else if(option == 7)
                {
                    int fee = std.feeCalculation(stdList);
                    Console.WriteLine("Fee of all subjects is {0}", fee);
                    Console.ReadKey();
                }
                else if(option == 8)
                {
                    break;
                }
            }
        }
        static int Menu()
        {
            Console.Clear();
            Console.WriteLine("1. Add Student.");
            Console.WriteLine("2. Add Degree program.");
            Console.WriteLine("3. Generate Merit.");
            Console.WriteLine("4. View Registered Students.");
            Console.WriteLine("5. View Students Of a Specific Program.");
            Console.WriteLine("6. Register Subjects For a Specific Student.");
            Console.WriteLine("7. Calculate the fee for all registered Students.");
            Console.WriteLine("8. Exit.");
            Console.WriteLine("Enter Option : ");
            int option;
            option = int.Parse(Console.ReadLine());
            return option;
        }

        
        static void viewRegisteredStudents(List<Student> stdList)
        {
            Console.Clear();
            foreach(Student s in stdList)
            {
                Console.WriteLine("{0}",s.name);
            }
            Console.ReadKey();
        }
        static void generateMerit(List<Student> studentList)
        {
            foreach(Student idx in studentList)
            {
                double merit = ((idx.fsc/11F)*0.6)+((idx.ecat / 4F) * 0.4F);
                idx.merit = merit;
            }
        }
        static void sortByMerit(List<Student> studentList)
        {
            for(int i = 0; i < studentList.Count; i++)
            {
                for(int j = 0; j<studentList.Count;j++)
                {
                    Student temp = new Student();
                    if (studentList[i].merit < studentList[j].merit)
                    {
                        temp = studentList[i];
                        studentList[i] = studentList[j];
                        studentList[j] = temp;
                    }
                }
            }
        }
        static void setAccordingToPrefrences(List<Student> std,List<DegreeProgram> dp)
        {
            for(int i = 0; i < dp.Count; i++)
            {
                int seats = dp[i].noOfSeats;
                for(int j = 0;j < std.Count; j++)
                {//std[k].prefrences[j].Count()
                    for (int k = 0; k < std[j].prefrences.Count; k++)
                    {
                       if (dp[i].degreeTitle == std[j].prefrences[k].degreeTitle && seats != 0)
                        {
                            Console.WriteLine("{0} got admission in {1}", std[i].name, dp[i].degreeTitle);
                            seats--;
                            break;
                        }
                    }
                }
            }
            Console.ReadKey();
        }
        static DegreeProgram AddDegreeProgram()
        {
            string degreeName,subType;
            int duration, seats,noOfSub,subCode,creditHour,subFees;
            List<Subjects> subList = new List<Subjects>();
            Console.WriteLine("Enter Degree Title : ");
            degreeName = Console.ReadLine();
            Console.WriteLine("Enter duration of degree : ");
            duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter available seats : ");
            seats = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter how many subjects you want to Enter :");
            noOfSub = int.Parse(Console.ReadLine());
            for (int i = 0; i < noOfSub; i++)
            {
                Console.WriteLine("Enter Subject Code : ");
                subCode = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Credit Hours : ");
                creditHour = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter subject Type : ");
                subType = Console.ReadLine();
                Console.WriteLine("Enter Subject Fees : ");
                subFees = int.Parse(Console.ReadLine());
                Subjects subje = new Subjects(subCode, creditHour, subType, subFees);
                subList.Add(subje);
            }
            DegreeProgram DG = new DegreeProgram(degreeName, duration, seats, subList);
            return DG;
        }
        static Student AddStudent(List<DegreeProgram> degreeList)
        {
            string name;
            int age, fsc, ecat, NoOfpref;
            List<DegreeProgram> pref = new List<DegreeProgram>();
            Console.WriteLine("Enter Student Name : ");
            name = Console.ReadLine();
            Console.WriteLine("Enter Student age : ");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter FSC Marks : ");
            fsc = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Ecat Marks : ");
            ecat = int.Parse(Console.ReadLine());
            Console.WriteLine("Available Degree Programs");
            int count = 0;
            foreach(DegreeProgram i in degreeList)
            {
                Console.WriteLine("{0}",i.degreeTitle);
                count++;
            }
            Console.WriteLine("Enter no of Prefrences : ");
            NoOfpref = int.Parse(Console.ReadLine());

            for(int i = 0; i < NoOfpref; i++)
            {
                Console.WriteLine("Enter prefrence : ");
                string take = Console.ReadLine();
                DegreeProgram item = new DegreeProgram(take);
                pref.Add(item);
            }
            Student st = new Student(name, age, fsc, ecat, NoOfpref, pref);
            return st;
        }
    }
}
