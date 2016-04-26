using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastikLigan
{
    public class Teams
    {
        private Dictionary<String, List<Gymnast>> _teams = new Dictionary<string, List<Gymnast>>(StringComparer.InvariantCultureIgnoreCase);

        public Dictionary<String, List<Gymnast>> AllTeams
        {
            get
            {
                return _teams;
            }
        }

        public void AddTeam(string team)
        {
            _teams.Add(team, new List<Gymnast>());
        }

        public void AddGymnastToTeam(string team, Gymnast gymnast)
        {
            _teams[team].Add(gymnast);
        }

        public bool ContainsTeam(string team)
        {
            return _teams.ContainsKey(team);
        }

        public string GetExactTeamName(string team)
        {
            return _teams.Keys.Where(k => k.ToLower() == team).FirstOrDefault();
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
