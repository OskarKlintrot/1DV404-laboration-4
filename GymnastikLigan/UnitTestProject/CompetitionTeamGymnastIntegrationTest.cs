using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymnastikLigan;

namespace UnitTestProject
{
    [TestClass]
    public class CompetitionTeamGymnastIntegrationTest
    {
        [TestMethod]
        public void CreateNewCompetition()
        {
            var teamName1 = "Smurfarna";
            var teamName2 = "Smurfhits";

            var team1 = new Team(teamName1);
            var team2 = new Team(teamName2);

            var gymnast1 = new Gymnast("Lisa");
            var gymnast2 = new Gymnast("Gammelsmurfen");
            var gymnast3 = new Gymnast("Bumbibjörnen");

            var teams = new Teams();

            var competition = new Competition("Gargamel", teams);

            teams.AddTeam(team1);
            teams.AddTeam(team2);
            teams.AddGymnastToTeam(teamName1, gymnast1);
            teams.AddGymnastToTeam(teamName2, gymnast2);
            teams.AddGymnastToTeam(teamName1, gymnast3);

            competition.AddTeam(teamName1);
            Assert.AreEqual(competition.AllTeams.Count, 1);
        }
    }
}
