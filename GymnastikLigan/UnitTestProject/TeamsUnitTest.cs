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
            var teams = new Teams();
            var name = "Smurfarna";
            teams.AddTeam(name);
            Assert.IsTrue(teams.AllTeams[name].Count == 0);
            try
            {
                teams.AllTeams[$"fel {name}"].ToString();
                Assert.Fail("Inget undantag kastades");
            }
            catch (KeyNotFoundException e)
            {
                Assert.IsNotNull(e);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message.ToString());
            }
        }

        [TestMethod]
        public void ValidateTeam()
        {
            var teams = new Teams();
            var name = "Smurfarna";
            Assert.IsFalse(teams.ContainsTeam(name.ToLower()));
            teams.AddTeam(name);
            Assert.IsTrue(teams.ContainsTeam(name.ToLower()));
        }

        [TestMethod]
        public void GetExactTeamName()
        {
            var teams = new Teams();
            var name = "Smurfarna";
            teams.AddTeam(name);
            Assert.IsTrue(teams.GetExactTeamName(name.ToLower()) == name);
        }
    }
}
