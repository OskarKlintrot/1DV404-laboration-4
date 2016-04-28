using System.Collections.Generic;

namespace GymnastikLigan
{
    public interface ICompetition
    {
        List<ITeam> AllTeams { get; }
        string AllTeamsAsString { get; }
        string Name { get; }
        List<string> Teams { get; }

        void AddTeam(string team);
    }
}