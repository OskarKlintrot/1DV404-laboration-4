using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymnastikLigan;

namespace UnitTestProject
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestUsername()
        {
            #region Initiate

            var username = "LisaSmurf";
            var password = "hemligt";
            var role = Role.secretary;
            var user = new User(username, password, role);

            #endregion

            #region Test

            #endregion

            #region Assert

            Assert.IsTrue(user.validateUsername(username), "Användarnamnet är fel.");
            Assert.IsFalse(user.validateUsername($"fel {username}"), "Användarnamnet är fel.");
            Assert.IsTrue(user.validateUsername(username.ToLower()), "Användarnamnet är fel.");
            Assert.IsFalse(user.validateUsername($"fel {username.ToLower()}"), "Användarnamnet är fel.");

            #endregion
        }

        [TestMethod]
        public void TestPassword()
        {
            #region Initiate

            var username = "LisaSmurf";
            var password = "hemligt";
            var role = Role.secretary;
            var user = new User(username, password, role);

            #endregion

            #region Test

            #endregion

            #region Assert

            Assert.IsTrue(user.validatePassword(password), "Rätt lösenord resulterade i ett fel");
            Assert.IsFalse(user.validatePassword($"fel {password}"), "Fel lösenord validerades som rätt");
            Assert.IsTrue(user.validatePassword(password.ToLower()), "Rätt lösenord resulterade i ett fel");
            Assert.IsFalse(user.validatePassword($"fel {password.ToLower()}"), "Fel lösenord validerades som rätt");

            #endregion
        }

        [TestMethod]
        public void TestRole()
        {
            #region Initiate

            var username = "LisaSmurf";
            var password = "hemligt";
            var role = Role.secretary;
            var user = new User(username, password, role);

            #endregion

            #region Test

            if (user.Role == Role.secretary) return;

            #endregion

            #region Assert

            Assert.IsTrue(user.Role == role, "Fel roll returnerades");
            Assert.IsFalse(user.Role == role + 1, "Fel roll returnerades");

            #endregion
        }
    }
}
