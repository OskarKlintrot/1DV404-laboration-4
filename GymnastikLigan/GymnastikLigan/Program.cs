using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastikLigan
{
    class Program
    {
        static void Main(string[] args)
        {
            Authentication.SetUser(CreateFirstUser());
            var choice = GetMenuChoice();
            do
            {
                switch (choice)
                {
                    case MenuChoice.login:
                        DoLogin();
                        Console.ReadKey();
                        break;
                    case MenuChoice.eatFood:
                        break;
                    case MenuChoice.quit:
                        break;
                    default:
                        break;
                }
                choice = GetMenuChoice();
            } while (choice != MenuChoice.quit);
        }

        private static void DoLogin()
        {
            string username;
            string password;
            var success = false;

            Console.Clear();
            Console.WriteLine("#################################");
            Console.WriteLine("#             LOGGA IN          #");
            Console.WriteLine("#################################");

            do
            {
                Console.Write("Ange användarnamn: ");
                username = Console.ReadLine();
                Console.Write("Ange lösenord: ");
                password = Console.ReadLine();
                success = Authentication.Login(username, password);
                if (!success)
                {
                    Console.WriteLine("Fel användarnamn eller lösenord, försök igen!");
                }
                else
                {
                    Console.WriteLine("Du är nu inloggad!");
                }

            } while (!success);
        }

        private static User CreateFirstUser()
        {
            var username = "LisaSmurf";
            var password = "hemligt";
            var role = Role.secretary;
            return new User(username, password, role);
        }

        private static MenuChoice GetMenuChoice()
        {
            Console.Clear();
            Console.WriteLine("#################################");
            Console.WriteLine("# GYMNASTIKLIGAN FOR THE WIN!!! #");
            if (!Authentication.LoggedIn)
            {
                Console.WriteLine("# 0. Logga in                   #");
            }
            else
            {
                Console.WriteLine("# 1. Något annat                #");
                Console.WriteLine("# 2. Äta mat                    #");
            }
            Console.WriteLine("#                               #");
            Console.WriteLine("# q. Avsluta                    #");
            Console.WriteLine("#################################");
            switch (Console.ReadLine()[0])
            {
                case '0':
                    return MenuChoice.login;
                default:
                    return MenuChoice.quit;
            }
        }
    }
}
