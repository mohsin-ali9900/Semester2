using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signupwithdiffrentclasses
{
    internal class MUserCRUD
    {
        static List<MUser> userList = new List<MUser>();

        public static void storeInList(MUser uusseer)
        {
            userList.Add(uusseer);
        }

        public static bool check(MUser user)
        {
            bool isExist = true;
            foreach(var use in userList)
            {
                if(use.UserName == user.UserName)
                {
                    isExist = false;
                }
            }
            return isExist;
        }

        public static string getRole(MUser user)
        {
            string Rolee = "";
            foreach(var uusseer in userList)
            {
                if(uusseer.UserName == user.UserName)
                {
                    Rolee = uusseer.Role;
                }
            }
            return Rolee;
        }
    }
}
