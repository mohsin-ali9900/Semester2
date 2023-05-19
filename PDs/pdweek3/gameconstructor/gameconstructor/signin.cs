using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class signin
    {
        public string username;
        public string password;
        public string role;
        public signin()
        {
            username = string.Empty;
            password = string.Empty;
            role = string.Empty;
        }
        public signin(string name,string pass, string roll)
        {
            username = name;
            password = pass;
            role = roll;
        }
        public signin(string nname, string ppassword)
        {
            username = nname;
            password = ppassword;
        }
    }

}