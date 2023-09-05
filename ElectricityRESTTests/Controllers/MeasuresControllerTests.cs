using System;
using System.Collections.Generic;
using ElectricityLibrary.model;
using ElectricityREST.Controllers;
using ElectricityREST.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YourTestNamespace
{
    // Defined a simple mock class for DataManager
    public class MockDataManager : DataManager
    {
        public MockDataManager() : base(null) 
        {
        }

        public List<Measure> GetAllMeasures()
        {
            // Simulate returning a list of measures
            return new List<Measure>
            {
                new Measure
                {
                    MeasureId = 1,
                    PowerUsed = 10.0,
                    PowerGenerated = 20.0,
                    CommunityId = 1,
                    ApartmentId = 101
                },
                new Measure
                {
                    MeasureId = 2,
                    PowerUsed = 15.0,
                    PowerGenerated = 25.0,
                    CommunityId = 2,
                    ApartmentId = 102
                },
            };
        }

        public Measure GetMeasureById(int measureId)
        {
            // Simulate returning a measure by ID
            if (measureId == 1)
            {
                return new Measure
                {
                    MeasureId = 1,
                    PowerUsed = 10.0,
                    PowerGenerated = 20.0,
                    CommunityId = 1,
                    ApartmentId = 101
                };
            }
            else
            {
                throw new Exception("Measure not found");
            }
        }
    }

    [TestClass] 
    public class MeasuresControllerTests
    {
        [TestMethod]
        public void GetAllMeasures_ReturnsOk()
        {
            // Arrange
            var dataManager = new MockDataManager(); // Use the MockDataManager
            var controller = new MeasuresController(dataManager);

            // Act
            var result = controller.GetAllMeasures();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var measureList = okResult.Value as List<Measure>;
            Assert.IsNotNull(measureList);

        }

        [TestMethod]
        public void GetMeasureById_ExistingId_ReturnsOk()
        {
            // Arrange
            var dataManager = new MockDataManager();
            var controller = new MeasuresController(dataManager);
            int measureId = 1;

            // Act
            var result = controller.GetMeasureById(measureId);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var measure = okResult.Value as Measure;
            Assert.IsNotNull(measure);
            Assert.AreEqual(measureId, measure.MeasureId);

        }

    }
}
