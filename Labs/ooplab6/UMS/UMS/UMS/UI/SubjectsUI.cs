using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.BL;

namespace UMS.UI
{
    internal class SubjectsUI
    {
        public static Subjects takeInputOfSubjects()
        {
            Console.WriteLine("Enter subject code : ");
            string code = Console.ReadLine();
            Console.WriteLine("Enter subject type : ");
            string type = Console.ReadLine();
            Console.WriteLine("Enter subject credit Hours : ");
            int creditHours = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Subject Fees : ");
            int subFees = int.Parse(Console.ReadLine());
            Subjects sub = new Subjects(code, type, creditHours, subFees);
            return sub;
        }
        public static void viewSubjects(Student st)
        {
            if(st.DegreeProgramObject != null)
            {
                Console.WriteLine("Sub Code\tSub Type");
                foreach(var s in st.DegreeProgramObject.subjects)
                {
                    Console.WriteLine(s.code + "\t\t" + s.type);
                }
            }
        }
        public static void registerSubjects(Student st)
        {
            Console.WriteLine("Enter how many subjects you want to enter :");
            int noOfSubWantToEnter = int.Parse(Console.ReadLine());
            for(int i = 0; i < noOfSubWantToEnter; i++)
            {
                Console.WriteLine("Enter the Subject Code : ");
                string codee = Console.ReadLine();
                bool flag = false;
                foreach(var s in st.DegreeProgramObject.subjects)
                {
                    if(s.code == codee)
                    {
                        if(st.registerStudentSubject(s))
                        {
                            flag = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("A Student can't have more than 9 credit hours.");
                            flag = true;
                            break;
                        }
                    }
                }
                if(flag == false)
                {
                    Console.WriteLine("Enter Valid Code.");
                    i--;
                }
            }
        }
    }
}
