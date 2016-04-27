using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastikLigan
{
    public class Teams
    {
        public Dictionary<String, List<Gymnast>> AllTeams { get; private set; }

        public Teams()
        {
            AllTeams = new Dictionary<string, List<Gymnast>>(StringComparer.InvariantCultureIgnoreCase);
        }

        public void AddTeam(string team)
        {
            AllTeams.Add(team, new List<Gymnast>());
        }

        public void AddGymnastToTeam(string team, Gymnast gymnast)
        {
            AllTeams[team].Add(gymnast);
        }

        public bool ContainsTeam(string team)
        {
            return AllTeams.ContainsKey(team);
        }

        public string GetExactTeamName(string team)
        {
            return AllTeams.Keys.Where(k => k.ToLower() == team).FirstOrDefault();
        }

        public override string ToString()
        {
            string teams = "Lag:\n";

            foreach (string key in AllTeams.Keys)
            {
                teams = teams + key + "\n";
            }

            return teams;
        }
    }
}
