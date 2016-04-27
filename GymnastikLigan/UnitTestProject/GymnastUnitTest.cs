using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymnastikLigan;

namespace UnitTestProject
{
    [TestClass]
    public class GymnastUnitTest
    {
        [TestMethod]
        public void CreateNewGymnast()
        {
            #region Initiate

            var name = "Pelle";
            var gymnast = new Gymnast(name);

            #endregion

            #region Test

            #endregion

            #region Assert

            Assert.IsTrue(gymnast.Name == name, "Namnet är fel.");
            Assert.IsFalse(gymnast.Name == $"fel {name}", "Namnet är fel.");
            foreach (Sport sport in Enum.GetValues(typeof(Sport)))
            {
                Assert.AreEqual(gymnast.Sports[sport], 0);
            }

            #endregion
        }

        [TestMethod]
        public void AddPointsToGymnast()
        {
            #region Initiate

            var name = "Pelle";
            var gymnast = new Gymnast(name);
            var sport = Sport.floorExercise;
            var points = 7.6;

            #endregion

            #region Test

            gymnast.Sports[sport] = points;

            #endregion

            #region Assert

            Assert.AreEqual(gymnast.Sports[sport], points);
            Assert.AreNotEqual(gymnast.Sports[sport], points + 1);

            #endregion
        }
    }
}
