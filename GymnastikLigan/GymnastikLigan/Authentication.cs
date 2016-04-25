using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastikLigan
{
    public static class Authentication
    {
        private static User _user;
        private static bool _loggedIn;

        private static User User
        {
            get
            {
                return _user;
            }

            set
            {
                _user = value;
            }
        }

        public static bool LoggedIn
        {
            get
            {
                return _loggedIn;
            }

            private set
            {
                _loggedIn = value;
            }
        }

        public static void SetUser(User user)
        {
            User = user;
        }

        public static bool Login(string username, string password)
        {
            LoggedIn = User.validatePassword(password) && User.validateUsername(username);
            return LoggedIn;
        }
    }
}
