using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BE
{
    public class User
    {
        public User(string user,string password)
        {
            Username = user;
            Password = password;
        }
        public User()
        {
            Username = "";
            Password = "";
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserSituation US { get; set; }
    }
}
