﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymnastikLigan;

namespace UnitTestProject
{
    [TestClass]
    public class CompetitionsUnitTest
    {
        [TestMethod]
        public void CreateCompetitions()
        {
            var competitions = new Competitions();
            Assert.IsNotNull(competitions.AllCompetitions);
        }

        [TestMethod]
        public void AddCompetitions()
        {
            var name = "Gargamel";
            var teams = new Teams();
            var competition = new Competition(name, teams);
            var competitions = new Competitions();
            competitions.AddCompetition(competition);
            Assert.IsTrue(competitions.GetCompetition(name).Teams.Count == 0);
            try
            {
                competitions.GetCompetition($"fel {name}").ToString();
                Assert.Fail("Inget undantag kastades");
            }
            catch (NullReferenceException)
            {

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message.ToString());
            }

            try
            {
                competitions.AddCompetition(competition);
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
        public void AddTeamToCompetitionTest()
        {
            var name = "Gargamel";
            var teamName = "Smurfarna";
            var team = new Team(teamName);
            var teams = new Teams();
            var competition = new Competition(name, teams);
            var competitions = new Competitions();

            teams.AddTeam(team);

            try
            {
                competitions.AddTeamToCompetition(name, teamName);
                competitions.AddTeamToCompetition(name, teamName);
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
        public void ValidateCompetition()
        {
            var name = "Gargamel";
            var teams = new Teams();
            var competition = new Competition(name, teams);
            var competitions = new Competitions();
            Assert.IsFalse(competitions.ContainsCompetition(name.ToLower()));
            competitions.AddCompetition(competition);
            Assert.IsTrue(competitions.ContainsCompetition(name.ToLower()));
        }

        [TestMethod]
        public void GetExactCompetitionName()
        {
            var name = "Gargamel";
            var teams = new Teams();
            var competition = new Competition(name, teams);
            var competitions = new Competitions();
            competitions.AddCompetition(competition);
            Assert.IsTrue(competitions.GetExactCompetitionName(name.ToLower()) == name);
        }

        [TestMethod]
        public void GetCompetition()
        {
            var name = "Gargamel";
            var teams = new Teams();
            var competition = new Competition(name, teams);
            var competitions = new Competitions();
            competitions.AddCompetition(competition);
            Assert.IsTrue(competitions.GetCompetition(name) == competition);
        }
    }
}
