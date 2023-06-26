using HospitalManager.Controllers;
using HospitalManager.Data;
using HospitalManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.HospitalManager.Tests
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public async Task Post_ValidUser_ReturnsUser()
        {
            // Arrange
            var context = new ApplicationDbContext();
            var controller = new UserController();

            var newUser = new User
            {
                UserName = "testuser",
                Password = "password"
            };

            // Act
            var result = await controller.Post(context, newUser);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ActionResult<User>));
            Assert.AreEqual(newUser.UserName, result.Value.UserName);
            Assert.AreEqual("", result.Value.Password);
        }

        [TestMethod]
        public async Task Post_ExceptionThrown_ReturnsBadRequest()
        {
            // Arrange
            var context = new ApplicationDbContext();
            var controller = new UserController();

            var newUser = new User
            {
                UserName = "testuser",
                Password = "password"
            };

            // Act
            var result = await controller.Post(context, newUser);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task Authenticate_ValidUser_ReturnsUserAndToken()
        {
            // Arrange
            var context = new ApplicationDbContext();
            var controller = new UserController();

            var user = new User
            {
                UserName = "testuser",
                Password = "password"
            };

            // Act
            var result = await controller.Authenticate(context, user);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ActionResult<dynamic>));
            Assert.IsNotNull(result.Value.user);
            Assert.IsNotNull(result.Value.token);
            Assert.AreEqual(user.UserName, result.Value.user.UserName);
            Assert.AreEqual("", result.Value.user.Password);
        }

        [TestMethod]
        public async Task Authenticate_InvalidUser_ReturnsNotFound()
        {
            // Arrange
            var context = new ApplicationDbContext();
            var controller = new UserController();

            var user = new User
            {
                UserName = "invaliduser",
                Password = "password"
            };

            // Act
            var result = await controller.Authenticate(context, user);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
