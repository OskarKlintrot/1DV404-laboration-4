using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastikLigan
{
    public class Competition : ICompetition
    {
        private ITeams teams { get; set; }
        public string Name { get; private set; }
        public List<string> Teams { get; private set; }
        public List<ITeam> AllTeams
        {
            get {
                return teams.AllTeams
                    .Where(t => Teams.IndexOf(t.Name) > -1)
                    .ToList();
            }
        }
        public string AllTeamsAsString
        {
            get
            {
                var collection = teams.AllTeams
                    .Where(t => Teams.IndexOf(t.Name) > -1)
                    .Select(t => t.Name)
                    .ToList();

                string ret = "";
                foreach (var item in collection)
                {
                    ret = String.IsNullOrEmpty(ret) ? item : ret + Environment.NewLine + item;
                }
                return ret;
            }
        }

        public Competition(string name, ITeams teams)
        {
            this.teams = teams;
            Teams = new List<string>();
            if (String.IsNullOrEmpty(name)) throw new ArgumentException();
            Name = name;
        }

        public void AddTeam(string team)
        {
            if (String.IsNullOrEmpty(team) || !teams.ContainsTeam(team))
                throw new ArgumentException();
            Teams.Add(team);
        }
    }
}
