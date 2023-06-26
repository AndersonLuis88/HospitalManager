using HospitalManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.HospitalManager.Tests
{
    [TestClass]
    public class PatientsControllerTests
    {
        [TestMethod]
        public async Task GetId_ValidId_ReturnsOkResult()
        {
            // Arrange

            var context = new Data.ApplicationDbContext();
            var controller = new PatientsController();

            // Act
            var result = await controller.GetId(1, context);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkResult));
        }
    }
}
