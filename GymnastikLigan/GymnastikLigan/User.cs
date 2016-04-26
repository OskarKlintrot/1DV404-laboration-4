using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastikLigan
{
    public class User
    {
        private string Username { get; set; }
        private string Password { get; set; }
        public Role Role { get; private set; }

        public User(string username, string password, Role role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        public bool validatePassword(string password)
        {
            return Password.ToLower() == password.ToLower();
        }

        public bool validateUsername(string username)
        {
            return Username.ToLower() == username.ToLower();
        }
    }
}
