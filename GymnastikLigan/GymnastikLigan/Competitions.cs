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
            AllCompetitions.Add(competition);
        }

        public void AddTeamToCompetition(string competition, string team)
        {
            if (!ContainsCompetition(competition)) return;

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
            string competitions = "Tävlingar:\n";

            foreach (var competition in AllCompetitions)
            {
                competitions = competitions + competition.Name + Environment.NewLine;
            }

            return competitions;
        }
    }
}
