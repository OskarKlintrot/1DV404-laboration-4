using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GymnastikLigan
{
    class Program
    {
        private static Regex _yOrN = new Regex("^(y|n){1}$", RegexOptions.IgnoreCase);
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
                        AddNewTeam(teams);
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

        private static void AddNewTeam(Teams teams)
        {
            Console.Write("Ange lagets namn: ");
            var newTeam = Console.ReadLine();
            string save;
            do
            {
                Console.WriteLine($"Vill du spara \"{newTeam}\" y/n?");
                save = Console.ReadLine();
                if (!_yOrN.IsMatch(save))
                    Console.Write($"Du kan bara använda \"y\" eller \"n\"! ");
            } while (!_yOrN.IsMatch(save));
            if (save[0] == 'y')
            {
                teams.AddTeam(newTeam);
                Console.WriteLine($"Det nya laget sparades! {StringResources._continue}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Laget sparades inte. {StringResources._continue}");
                Console.ReadKey();
            }
        }

        private static void ShowTeams(Teams teams)
        {
            Console.WriteLine(teams.ToString());
            Console.WriteLine("För att lägga till eller visa spelare för ett lag, skriv lagets namn. \nAnnars tryck enter för att återgå till startmenyn.");
            var choosedTeam = Console.ReadLine();
            while (!teams.ContainsTeam(choosedTeam))
            {
                Console.WriteLine("Laget hittades inte, försök igen.");
                choosedTeam = Console.ReadLine();
            }
            Console.WriteLine($"Du valde {teams.GetExactTeamName(choosedTeam)}");
            Console.WriteLine("Lagets gymnaster är: ");
            foreach (var player in teams.AllTeams[choosedTeam])
            {
                Console.WriteLine(player.ToString());
            }
            Console.Write("Vill du lägga till en ny gymnast? y/n: ");
            string save;
            do
            {
                save = Console.ReadLine();
                if (!_yOrN.IsMatch(save))
                    Console.Write($"Du kan bara använda \"y\" eller \"n\"! ");
                else if (save[0] == 'n')
                    return;
            } while (!_yOrN.IsMatch(save));
            Console.Write("Ange namnet på den gymnast du vill lägga till: ");
            var newGymnast = Console.ReadLine();
            save = "";
            do
            {
                Console.Write($"Vill du spara \"{newGymnast}\"? y/n: ");
                save = Console.ReadLine();
                if (!_yOrN.IsMatch(save))
                    Console.Write($"Du kan bara använda \"y\" eller \"n\": ");
            } while (!_yOrN.IsMatch(save));
            if (save[0] == 'y')
            {
                teams.AddGymnastToTeam(choosedTeam, new Gymnast(newGymnast));
                Console.WriteLine($"Den nya gymnasten sparades! {StringResources._continue}");
            }
            else
            {
                Console.WriteLine($"Gymnasten sparades inte. {StringResources._continue}");
            }
            Console.ReadKey();
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
