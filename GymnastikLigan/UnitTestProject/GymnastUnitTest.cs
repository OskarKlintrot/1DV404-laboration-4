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

            var name = "Lalalaiza";
            var gymnast = new Gymnast(name);

            #endregion

            #region Test

            #endregion

            #region Assert

            Assert.IsTrue(gymnast.Name == name, "Namnet är fel.");
            Assert.IsFalse(gymnast.Name == $"fel {name}", "Namnet är fel.");

            #endregion
        }
    }
}
