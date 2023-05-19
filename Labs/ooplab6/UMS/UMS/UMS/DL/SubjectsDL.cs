using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.BL;

namespace UMS.DL
{
    internal class SubjectsDL
    {
        public static List<Subjects> subjectsList = new List<Subjects>();
        public static void addSubjectIntoList(Subjects s)
        {
            subjectsList.Add(s);
        }
    }
}
