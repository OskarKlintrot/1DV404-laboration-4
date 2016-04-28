using System.Collections.Generic;

namespace GymnastikLigan
{
    public interface ITeams
    {
        List<ITeam> AllTeams { get; }

        void AddGymnastToTeam(string team, IGymnast gymnast);
        void AddTeam(ITeam team);
        bool ContainsTeam(string team);
        string GetExactTeamName(string team);
        ITeam GetTeam(string team);
        string ToString();
    }
}