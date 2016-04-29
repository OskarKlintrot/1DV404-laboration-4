using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymnastikLigan;

namespace UnitTestProject
{
    [TestClass]
    public class CompetitionUnitTest
    {
        [TestMethod]
        public void CreateNewCompetition()
        {
            try
            {
                var teams = new Teams();
                var competition = new Competition("Gargamel", teams);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}
