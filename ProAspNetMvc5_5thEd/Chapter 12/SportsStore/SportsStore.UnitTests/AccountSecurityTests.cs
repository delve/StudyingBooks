using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Models;
using System.Web.Mvc;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class AccountSecurityTests
    {
        /// <summary>
        /// Get a consistent IAuthProvider implementation to test with
        /// </summary>
        /// <returns>Test IAuthProvider implementation</returns>
        private IAuthProvider GetAuthenticationProvider()
        {
            Mock<IAuthProvider> mock = new Mock<IAuthProvider>();
            mock.Setup(m => m.Authenticate("admin", "secret")).Returns(true);
            mock.Setup(m => m.Authenticate("baduser", "badpass")).Returns(false);

            return mock.Object;
        }

        /// <summary>
        /// Assert that valid credentials get logged in by AccountController
        /// </summary>
        [TestMethod]
        public void CanLoginWithValidCredentials()
        {
            // Arrange
            IAuthProvider mock = GetAuthenticationProvider();
            LoginViewModel model = new LoginViewModel { UserName = "admin", Password = "secret" };
            AccountController target = new AccountController(mock);

            // Act
            ActionResult result = target.Login(model, "/MyUrl");

            // Assertion
            Assert.IsInstanceOfType(result, typeof(RedirectResult));
            Assert.AreEqual("/MyUrl", ((RedirectResult)result).Url);
        }

        /// <summary>
        /// Assert that invalid credentials are not logged in by AccountController
        /// </summary>
        [TestMethod]
        public void CannotLoginWithInvalidCredentials()
        {
            // Arrange
            IAuthProvider mock = GetAuthenticationProvider();
            LoginViewModel model = new LoginViewModel { UserName = "baduser", Password = "badpass" };
            AccountController target = new AccountController(mock);

            // Act
            ActionResult result = target.Login(model, "/MyUrl");

            // Assertion
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsFalse(((ViewResult)result).ViewData.ModelState.IsValid);
        }
    }
}
