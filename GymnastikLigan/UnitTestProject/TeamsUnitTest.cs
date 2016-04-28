using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymnastikLigan;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class TeamsUnitTest
    {
        [TestMethod]
        public void CreateTeams()
        {
            var teams = new Teams();
            Assert.IsNotNull(teams.AllTeams);
        }

        [TestMethod]
        public void AddTeams()
        {
            var name = "Smurfarna";
            var team = new Team(name);
            var teams = new Teams();
            teams.AddTeam(team);
            Assert.IsTrue(teams.GetTeam(name).Gymnasts.Count == 0);
            try
            {
                teams.GetTeam($"fel {name}").ToString();
                Assert.Fail("Inget undantag kastades");
            }
            catch (KeyNotFoundException e)
            {
                Assert.IsNotNull(e);
            }
            catch (Exception)
            {
            }
        }

        [TestMethod]
        public void ValidateTeam()
        {
            var name = "Smurfarna";
            var team = new Team(name);
            var teams = new Teams();
            Assert.IsFalse(teams.ContainsTeam(name.ToLower()));
            teams.AddTeam(team);
            Assert.IsTrue(teams.ContainsTeam(name.ToLower()));
        }

        [TestMethod]
        public void GetExactTeamName()
        {
            var name = "Smurfarna";
            var team = new Team(name);
            var teams = new Teams();
            teams.AddTeam(team);
            Assert.IsTrue(teams.GetExactTeamName(name.ToLower()) == name);
        }

        [TestMethod]
        public void GetTeam()
        {
            var name = "Smurfarna";
            var team = new Team(name);
            var teams = new Teams();
            teams.AddTeam(team);
            Assert.IsTrue(teams.GetTeam(name) == team);
        }
    }
}
