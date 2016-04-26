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
            var teams = InstanziateProject();

            Authentication.SetUser(CreateFirstUser());

            var choice = GetMenuChoice();
            while (choice != MenuChoice.quit)
            {
                switch (choice)
                {
                    case MenuChoice.login:
                        DoLogin();
                        break;
                    case MenuChoice.quit:
                        break;
                    case MenuChoice.logout:
                        Authentication.Logout();
                        break;
                    case MenuChoice.showTeams:
                        ShowTeams(teams);
                        break;
                    case MenuChoice.addTeam:
                        break;
                    case MenuChoice.showCompetitions:
                        break;
                    case MenuChoice.addCompetition:
                        break;
                    default:
                        break;
                }
                choice = GetMenuChoice();
            }
        }

        private static string ShowTeams(Teams teams)
        {
            Console.Clear();
            Console.WriteLine(teams.ToString());
            Console.WriteLine("För att lägga till eller visa spelare för ett lag, skriv lagets namn. \nAnnars tryck enter för att återgå till startmenyn.");
            var choice = Console.ReadLine();
            while (!teams.ContainsTeam(choice))
            {
                if (String.IsNullOrWhiteSpace(choice)) return "";

                Console.WriteLine("Laget hittades inte, försök igen.");
                choice = Console.ReadLine();
            }
            Console.WriteLine($"Du valde {teams.GetExactTeamName(choice)}");
            Console.WriteLine(StringResources._continue);
            Console.ReadKey();
            return choice;
        }

        private static Teams InstanziateProject()
        {
            var teamName1 = "Smurfarna";
            var teamName2 = "Smurfhits";

            var gymnast1 = new Gymnast("Lisa");
            var gymnast2 = new Gymnast("Gammelsmurfen");
            var gymnast3 = new Gymnast("Bumbibjörnen");

            var teams = new Teams();

            teams.AddTeam(teamName1);
            teams.AddTeam(teamName2);
            teams.AddGymnastToTeam(teamName1, gymnast1);
            teams.AddGymnastToTeam(teamName2, gymnast2);
            teams.AddGymnastToTeam(teamName1, gymnast3);

            return teams;
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
                    Console.WriteLine($"Du är nu inloggad! {StringResources._continue}");
                    Console.ReadKey();
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
            Console.WriteLine("# GYMNASTIKLIGAN FOR THE WIN! #");
            if (!Authentication.LoggedIn)
            {
                Console.WriteLine("# 1. Logga in                 #");
            }
            else
            {
                Console.WriteLine("# 1. Logga ut                 #");
                Console.WriteLine("# 2. Visa lag                 #");
                Console.WriteLine("# 3. Lägg till lag            #");
                Console.WriteLine("# 4. Visa tävlingar           #");
                Console.WriteLine("# 5. Lägg till tävling        #");
            }
            Console.WriteLine("#                             #");
            Console.WriteLine("# q. Avsluta                  #");
            Console.WriteLine("###############################");
            var option = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(option)) return MenuChoice.quit;
            switch (option[0])
            {
                case '1':
                    return !Authentication.LoggedIn ? MenuChoice.login : MenuChoice.logout;
                case '2':
                    return MenuChoice.showTeams;
                case '3':
                    return MenuChoice.addTeam;
                case '4':
                    return MenuChoice.showCompetitions;
                case '5':
                    return MenuChoice.addCompetition;
                default:
                    return MenuChoice.quit;
            }
        }
    }
}
