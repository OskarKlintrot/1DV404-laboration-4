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

            try
            {
                teams.AddTeam(team);
                throw new Exception();
            }
            catch (ArgumentException)
            {

            }
            catch (Exception)
            {
                Assert.Fail("Fel undantag kastades");
            }
        }

        [TestMethod]
        public void AddGymnastToTeam()
        {
            var teamName = "Smurfarna";
            var gymnastName = "Smurfarna";
            var gymnast = new Gymnast(gymnastName);
            var team = new Team(teamName);
            var teams = new Teams();
            var competition = new Competition(teamName, teams);
            var competitions = new Competitions();

            teams.AddTeam(team);

            try
            {
                teams.AddGymnastToTeam(teamName, gymnast);
                teams.AddGymnastToTeam(teamName, gymnast);
                throw new Exception();
            }
            catch (ArgumentException)
            {

            }
            catch (Exception)
            {
                Assert.Fail("Fel undantag kastades");
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
