using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymnastikLigan;

namespace UnitTestProject
{
    [TestClass]
    public class TeamsGymnastIntegrationTest
    {
        [TestMethod]
        public void AddGymnastToTeam()
        {
            var teamName = "Smurfarna";
            var gymnastName = "Lisa";
            var team = new Team(teamName);
            var teams = new Teams();
            var gymnast = new Gymnast(gymnastName);

            teams.AddTeam(team);
            Assert.IsTrue(teams.GetTeam(teamName).Gymnasts.Count == 0);
            teams.AddGymnastToTeam(teamName, gymnast);
            Assert.IsTrue(teams.GetTeam(teamName).Gymnasts.Count == 1);
        }
    }
}
