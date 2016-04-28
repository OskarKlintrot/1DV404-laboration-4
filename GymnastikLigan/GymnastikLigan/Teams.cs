using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastikLigan
{
    public class Teams : ITeams
    {
        public List<ITeam> AllTeams { get; private set; }

        public Teams()
        {
            AllTeams = new List<ITeam>();
        }

        public void AddTeam(ITeam team)
        {
            AllTeams.Add(team);
        }

        public void AddGymnastToTeam(string team, IGymnast gymnast)
        {
            if (!ContainsTeam(team)) return;

            AllTeams
                .Find(t => t.Name.ToLower() == team.ToLower())
                .AddGymnast(gymnast);
        }

        public bool ContainsTeam(string team)
        {
            try
            {
                AllTeams.Find(t => t.Name.ToLower() == team.ToLower()).ToString();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public ITeam GetTeam(string team)
        {
            return AllTeams.Find(t => t.Name.ToLower() == team.ToLower());
        }

        public string GetExactTeamName(string team)
        {
            return AllTeams.Find(t => t.Name.ToLower() == team.ToLower()).Name;
        }

        public override string ToString()
        {
            string teams = "Lag:\n";

            foreach (var team in AllTeams)
            {
                teams = teams + team.Name + "\n";
            }

            return teams;
        }
    }
}
