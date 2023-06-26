using HospitalManager.Controllers;
using HospitalManager.Data;
using HospitalManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManager.HospitalManager.Tests
{
    [TestClass]
    public class MedicalRecordsControllerTests
    {
        private MedicalRecordsController _controller;
        private ApplicationDbContext _context;

        [TestInitialize]
        public void Setup()
        {
            _context = new ApplicationDbContext();
            _controller = new MedicalRecordsController();
        }

        [TestMethod]
        public async Task Get_ReturnsOkResult()
        {
            // Arrange

            // Act
            var result = await _controller.Get(_context);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<List<Ficha>>));
            Assert.IsTrue(result.Result is OkObjectResult);
        }

        [TestMethod]
        public async Task GetId_ReturnsOkResult()
        {
            // Arrange
            int id = 1;

            // Act
            var result = await _controller.GetId(id, _context);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Ficha>));
            Assert.IsTrue(result.Result is OkObjectResult);
        }

        [TestMethod]
        public async Task Post_ReturnsOkResult()
        {
            // Arrange
            Ficha ficha = new Ficha();

            // Act
            var result = await _controller.Post(ficha, _context);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<List<Ficha>>));
            Assert.IsTrue(result.Result is OkObjectResult);
        }

        [TestMethod]
        public async Task Put_ReturnsOkResult()
        {
            // Arrange
            int id = 1;
            Ficha ficha = new Ficha();

            // Act
            var result = await _controller.Put(id, ficha, _context);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<List<Ficha>>));
            Assert.IsTrue(result.Result is OkObjectResult);
        }

        [TestMethod]
        public async Task Delete_ReturnsOkResult()
        {
            // Arrange
            int id = 1;

            // Act
            var result = await _controller.Delete(id, _context);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<List<Ficha>>));
            Assert.IsTrue(result.Result is OkObjectResult);
        }
    }
}
