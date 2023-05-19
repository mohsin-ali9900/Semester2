using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.BL;

namespace UMS.DL
{
    internal class StudentDL
    {
        public static List<Student> stList = new List<Student>();
        public static void addIntoStudentList(Student s)
        {
            stList.Add(s);
        }
        public static Student studentPresent(string name)
        {
            foreach(var ss in stList)
            {
                if(ss.name == name && ss.DegreeProgramObject != null)
                {
                    return ss;
                }
            }
            return null;
        }
        public static List<Student> sortStudentByMerit()
        {
            List<Student> sortedList = new List<Student>();
            foreach(var s in stList)
            {
                s.calculateMerit();
            }
            sortedList = stList.OrderByDescending(o => o.merit).ToList();
            return sortedList;
        }
        // generate merit.....
        public static void giveAdmission(List<Student> sortedStudentList)
        {
            foreach(var s in sortedStudentList)
            {
                foreach(var d in s.prefrences)
                {
                    if(d.seats > 0 && s.DegreeProgramObject == null)
                    {
                        s.DegreeProgramObject = d;
                        d.seats--;
                        break;
                    }
                }
            }
        }
    }
}
