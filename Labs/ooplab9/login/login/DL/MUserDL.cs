using login.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login.DL
{
    internal class MUserDL
    {
        private static List<MUser> userList = new List<MUser>();

        public static void addUserIntoList(MUser user)
        {
            userList.Add(user);
        }
        public static MUser SignIn(MUser user) 
        {
            foreach(MUser storedUser in userList)
            {
                if (storedUser.getUsername() == user.getUsername() && storedUser.getUserPassword() == user.getUserPassword())
                {
                    return storedUser;
                }
            }
            return null;
        }
        public static string parseData(string record,int field)
        {
            int comma = 1;
            string item = "";
            for(int i = 0; i < record.Length;i++)
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
        public static bool readDataFromFile()
        {

        }
    }
}
