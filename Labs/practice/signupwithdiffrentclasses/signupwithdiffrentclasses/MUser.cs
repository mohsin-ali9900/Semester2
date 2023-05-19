using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signupwithdiffrentclasses
{
    internal class MUser
    {
        public string UserName;
        public string UserPassword;
        public string Role;

        public MUser(string name, string password, string role)
        {
            this.UserName = name;
            this.UserPassword = password;
            this.Role = role;
        }

        public MUser(string name, string password)
        {
            this.UserName = name;
            this.UserPassword = password;
        }
    }
}
