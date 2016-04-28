using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymnastikLigan;

namespace UnitTestProject
{
    [TestClass]
    public class TeamUnitTest
    {
        [TestMethod]
        public void CreateNewTeam()
        {
            try
            {
                var team = new Team("Smurfarna");
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}
