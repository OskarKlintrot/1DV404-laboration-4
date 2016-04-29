using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastikLigan
{
    public class Competitions : ICompetitions
    {
        public List<ICompetition> AllCompetitions { get; private set; }

        public Competitions()
        {
            AllCompetitions = new List<ICompetition>();
        }

        public void AddCompetition(ICompetition competition)
        {
            if (AllCompetitions.FindIndex(c => c.Name.ToLower() == competition.Name.ToLower()) > -1) throw new ArgumentException("The competition already exists.");
            AllCompetitions.Add(competition);
        }

        public void AddTeamToCompetition(string competition, string team)
        {
            if (!ContainsCompetition(competition)) throw new ArgumentOutOfRangeException("The competition doesn't exist.");
            if (AllCompetitions.Exists(c => c.Teams.Exists(t => t.ToLower() == team.ToLower()))) throw new ArgumentException("The team already exists.");

            AllCompetitions
                .Find(t => t.Name.ToLower() == competition.ToLower())
                .AddTeam(team);
        }

        public bool ContainsCompetition(string competition)
        {
            try
            {
                AllCompetitions.Find(t => t.Name.ToLower() == competition.ToLower()).ToString();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public ICompetition GetCompetition(string competition)
        {
            return AllCompetitions.Find(t => t.Name.ToLower() == competition.ToLower());
        }

        public string GetExactCompetitionName(string competition)
        {
            return AllCompetitions.Find(t => t.Name.ToLower() == competition.ToLower()).Name;
        }

        public override string ToString()
        {
            string competitions = $"Tävlingar:{Environment.NewLine}";

            foreach (var competition in AllCompetitions)
            {
                competitions = competitions + competition.Name + Environment.NewLine;
            }

            return competitions;
        }
    }
}
