using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SellerPlatform;
using System;

namespace SellerPlatformTests
{
    [TestClass]
    public class LoginFormTests
    {
        [TestMethod]
        public void ValidateLogin_ValidCredentials_ReturnsTrue()
        {
            var mockConnection = new Mock<MySql.Data.MySqlClient.MySqlConnection>();
            var mockCommand = new Mock<MySql.Data.MySqlClient.MySqlCommand>();
            var loginForm = new LoginForm();

            mockCommand.Setup(cmd => cmd.ExecuteScalar())
                       .Returns(BCrypt.Net.BCrypt.HashPassword("validPassword"));

            bool result = loginForm.ValidateLogin("validUser", "validPassword");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateLogin_InvalidPassword_ReturnsFalse()
        {
            var mockConnection = new Mock<MySql.Data.MySqlClient.MySqlConnection>();
            var mockCommand = new Mock<MySql.Data.MySqlClient.MySqlCommand>();
            var loginForm = new LoginForm();

            mockCommand.Setup(cmd => cmd.ExecuteScalar())
                       .Returns(BCrypt.Net.BCrypt.HashPassword("validPassword"));

            bool result = loginForm.ValidateLogin("validUser", "wrongPassword");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateLogin_InvalidUsername_ReturnsFalse()
        {
            var mockConnection = new Mock<MySql.Data.MySqlClient.MySqlConnection>();
            var mockCommand = new Mock<MySql.Data.MySqlClient.MySqlCommand>();
            var loginForm = new LoginForm();

            mockCommand.Setup(cmd => cmd.ExecuteScalar()).Returns((string)null);

            bool result = loginForm.ValidateLogin("invalidUser", "anyPassword");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateLogin_DatabaseError_ReturnsFalse()
        {
            var mockConnection = new Mock<MySql.Data.MySqlClient.MySqlConnection>();
            var mockCommand = new Mock<MySql.Data.MySqlClient.MySqlCommand>();
            var loginForm = new LoginForm();

            mockCommand.Setup(cmd => cmd.ExecuteScalar()).Throws(new Exception("Database error"));

            bool result = loginForm.ValidateLogin("anyUser", "anyPassword");

            Assert.IsFalse(result);
        }
    }
}