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
            var teams = new Teams();
            var competitions = new Competitions();
            InstanziateProject(teams, competitions);

            Authentication.SetUser(CreateFirstUser());
            Authentication.Login("LisaSmurf", "hemligt");

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
                        var choosedTeam = ShowTeams(teams);
                        if (String.IsNullOrEmpty(choosedTeam)) break;
                        addNewGymnastToTeam(teams, choosedTeam);
                        break;
                    case MenuChoice.addTeam:
                        AddNewTeam(teams);
                        break;
                    case MenuChoice.showCompetitions:
                        var choosedCompetition = showCompetitions(competitions);
                        break;
                    case MenuChoice.addCompetition:
                        break;
                    default:
                        break;
                }
                choice = GetMenuChoice();
            }
        }

        private static string showCompetitions(Competitions competitions)
        {
            //Console.WriteLine(competitions.AllTeamsAsString);
            Console.WriteLine(competitions.ToString());
            Console.WriteLine(StringResources._continue);
            Console.ReadKey();





            //Console.WriteLine(competition.AllTeamsAsString);
            //Console.WriteLine($"För att lägga till eller visa spelare för ett lag, skriv lagets namn.{Environment.NewLine}Annars tryck enter för att återgå till startmenyn.");
            //var choosedCompetition = Console.ReadLine();
            //if (String.IsNullOrEmpty(choosedCompetition)) return null;
            //while (!competition.ContainsTeam(choosedCompetition))
            //{
            //    Console.WriteLine("Laget hittades inte, försök igen.");
            //    choosedCompetition = Console.ReadLine();
            //}
            //Console.WriteLine($"Du valde {teams.GetExactTeamName(choosedCompetition)}");
            //Console.WriteLine("Lagets gymnaster är: ");
            //foreach (var player in teams.GetTeam(choosedCompetition).Gymnasts)
            //{
            //    Console.WriteLine(player.ToString());
            //}
            //return choosedCompetition;
            return null;
        }

        private static void AddNewTeam(Teams teams)
        {
            string newTeam;
            string save = "n";
            Console.Write("Ange lagets namn: ");
            do
            {
                newTeam = Console.ReadLine().Trim();
                if (!String.IsNullOrEmpty(newTeam))
                {
                    Console.WriteLine($"Vill du spara \"{newTeam}\" y/n?");
                    save = Console.ReadLine();
                }
                else
                {
                    Console.Write($"Lagets namn är ogiltigt, försök igen: ");
                }
                if (!_yOrN.IsMatch(save))
                    Console.Write($"Du kan bara använda \"y\" eller \"n\"! ");
            } while (!_yOrN.IsMatch(save) || String.IsNullOrEmpty(newTeam));
            if (save[0] == 'y')
            {
                teams.AddTeam(new Team(newTeam));
                Console.WriteLine($"Det nya laget sparades! {StringResources._continue}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Laget sparades inte. {StringResources._continue}");
                Console.ReadKey();
            }
        }

        private static string ShowTeams(Teams teams)
        {
            Console.WriteLine(teams.ToString());
            Console.WriteLine("För att lägga till eller visa spelare för ett lag, skriv lagets namn. \nAnnars tryck enter för att återgå till startmenyn.");
            var choosedTeam = Console.ReadLine();
            if (String.IsNullOrEmpty(choosedTeam)) return null;
            while (!teams.ContainsTeam(choosedTeam))
            {
                Console.WriteLine("Laget hittades inte, försök igen.");
                choosedTeam = Console.ReadLine();
            }
            Console.WriteLine($"Du valde {teams.GetExactTeamName(choosedTeam)}");
            Console.WriteLine("Lagets gymnaster är: ");
            foreach (var player in teams.GetTeam(choosedTeam).Gymnasts)
            {
                Console.WriteLine(player.ToString());
            }
            return choosedTeam;
        }

        private static void addNewGymnastToTeam(Teams teams, string choosedTeam)
        {
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
            while (String.IsNullOrEmpty(newGymnast))
            {
                Console.Write($"Gymnastens namn är ogiltigt, försök igen: ");
                newGymnast = Console.ReadLine();
            }
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

        private static void InstanziateProject(Teams teams, Competitions competitions)
        {
            var teamName1 = "Smurfarna";
            var teamName2 = "Smurfhits";
            var competitionName = "Gargamel";

            var team1 = new Team(teamName1);
            var team2 = new Team(teamName2);

            var gymnast1 = new Gymnast("Lisa");
            var gymnast2 = new Gymnast("Gammelsmurfen");
            var gymnast3 = new Gymnast("Bumbibjörnen");

            var competition = new Competition(competitionName, teams);

            teams.AddTeam(team1);
            teams.AddTeam(team2);
            teams.AddGymnastToTeam(teamName1, gymnast1);
            teams.AddGymnastToTeam(teamName2, gymnast2);
            teams.AddGymnastToTeam(teamName1, gymnast3);

            competitions.AddTeamToCompetition(competitionName, teamName1);
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
