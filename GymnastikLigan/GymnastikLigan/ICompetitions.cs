using System.Collections.Generic;

namespace GymnastikLigan
{
    public interface ICompetitions
    {
        List<ICompetition> AllCompetitions { get; }

        void AddCompetition(ICompetition competition);
        void AddTeamToCompetition(string competition, string team);
        bool ContainsCompetition(string competition);
        ICompetition GetCompetition(string competition);
        string GetExactCompetitionName(string competition);
        string ToString();
    }
}