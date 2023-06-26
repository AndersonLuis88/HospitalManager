using HospitalManager.Models;
using HospitalManager.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.HospitalManager.Tests
{
    [TestClass]
    public class TokenServiceTests
    {
        [TestMethod]
        public void GenerateToken_ValidUser_ReturnsToken()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Role = "Admin"
            };

            // Act
            var token = TokenService.GenerateToken(user);

            // Assert
            Assert.IsNotNull(token);
            Assert.IsTrue(token.Length > 0);
        }
    }
}
