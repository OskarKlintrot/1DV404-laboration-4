using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymnastikLigan;

namespace UnitTestProject
{
    [TestClass]
    public class AuthenticationTest
    {
        [TestMethod]
        public void SetUser()
        {
            #region Initiate

            var username = "LisaSmurf";
            var password = "hemligt";
            var role = Role.secretary;
            var user = new User(username, password, role);

            #endregion

            #region Test

            try
            {
                Authentication.SetUser(user);
            }

            #endregion

            #region Assert

            catch (Exception)
            {
                Assert.Fail("Det gick inte att sätta användaren.");
            }

            #endregion
        }

        [TestMethod]
        public void Login()
        {
            #region Initiate

            var username = "LisaSmurf";
            var password = "hemligt";
            var role = Role.secretary;
            var user = new User(username, password, role);

            #endregion

            #region Test

            Authentication.SetUser(user);

            #endregion

            #region Assert

            Assert.IsTrue(Authentication.Login(username,password), "Användaren kunde inte logga in med rätt lösenord");
            Assert.IsFalse(Authentication.Login(username, $"fel {password}"), "Användaren kunde logga in med fel lösenord");
            Assert.IsFalse(Authentication.Login($"fel {username}", password), "Användaren kunde logga in med fel användarnamn");
            Assert.IsFalse(Authentication.Login($"fel {username}", $"fel {password}"), "Användaren kunde logga in med fel användarnamn och lösenord");

            #endregion
        }

        [TestMethod]
        public void Logout()
        {
            #region Initiate

            var username = "LisaSmurf";
            var password = "hemligt";
            var role = Role.secretary;
            var user = new User(username, password, role);
            
            #endregion

            #region Test

            Authentication.SetUser(user);
            Authentication.Login(username, password);

            #endregion

            #region Assert

            Assert.IsTrue(Authentication.LoggedIn, "Användaren kunde inte logga in");
            Authentication.Logout();
            Assert.IsFalse(Authentication.LoggedIn, "Användaren kunde inte logga ut");

            #endregion
        }
    }
}
