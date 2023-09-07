using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using ElectricityREST.Controllers;
using ElectricityLibrary.model;

namespace ElectricityREST.Controllers.Tests
{
    [TestClass]
    public class MeasuresControllerTests
    {
        private ELDBContext _context;
        private MeasuresController _controller;

        [TestInitialize]
        public void Initialize()
        {
            // Use connectionstring to connect to the test database
            var connectionString = @"data source=BLADE;initial catalog=ElPraktik;trusted_connection=true;Encrypt=False;";
            var options = new DbContextOptionsBuilder<ELDBContext>()
                .UseSqlServer(connectionString)
                .Options;

            _context = new ELDBContext(options);
            _controller = new MeasuresController(_context);
        }

        [TestMethod]
        public void GetAllMeasuresTest()
        {
            // Act
            var result = _controller.GetAllMeasures();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Dispose of the database context after each test
            _context.Dispose();
        }
    }
}
