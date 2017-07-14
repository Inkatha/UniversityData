using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UniversityData.BindingModels.CostToAttend;
using UniversityData.Controllers;
using UniversityData.Models;
using UniversityData.Services.Interfaces;
using Xunit;

namespace UniversityData.Tests.Unit.Controller
{
    public class CostToAttendTests
    {
        [Fact]
        public void ShouldReturnNotFoundIfSchoolIdIsNotFound()
        {
            // Arrange
            var unitId = 9999999;
            var mockRepo = GetMockRepository(unitId);
            var mockLogger = GetMockLogger();
            var controller = new CostToAttendController(mockRepo.Object, mockLogger.Object);

            // Act
            var actionResult = controller.GetSchoolCostToAttend(unitId).Result;

            // Assert
            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Fact]
        public void ShouldReturnOkIfSchoolIdIsFound()
        {
            //Arrange
            var unitId = 100663;
            var mockRepo = GetMockRepository(unitId);
            var mockLogger = GetMockLogger();
            var controller = new CostToAttendController(mockRepo.Object, mockLogger.Object);

            // Act
            var actionResult = controller.GetSchoolCostToAttend(unitId);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public void ShouldOnlyReturnPrivateSchools()
        {
            // Arrange
            var unitId = 100663;
            var mockRepo = GetMockRepository(unitId);
            var mockLogger = GetMockLogger();
            var controller = new CostToAttendController(mockRepo.Object, mockLogger.Object);

            // Act
            var actionResult = controller.GetCostToAttendPrivateSchoolByIncome(unitId);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public void ShouldOnlyReturnPublicSchools()
        {
            // Arrange
            var unitId = 100663;
            var mockRepo = GetMockRepository(unitId);
            var mockLogger = GetMockLogger();
            var controller = new CostToAttendController(mockRepo.Object, mockLogger.Object);

            // Act
            var actionResult = controller.GetCostToAttendPrivateSchoolByIncome(50000);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        private Mock<ILogger<CostToAttendController>> GetMockLogger()
        {
            var mockLogger = new Mock<ILogger<CostToAttendController>>();
            return mockLogger;
        }

        private Mock<ICostToAttendRepository> GetMockRepository(int unitId)
        {
            var mockRepo = new Mock<ICostToAttendRepository>();

            mockRepo.Setup(repo => 
                repo.GetSchoolCostToAttendAsync(unitId)
            ).Returns(Task.FromResult(GetTestCostToAttend()
            .FirstOrDefault(s => s.schoolid == unitId)));

            return mockRepo;
        }

        private IEnumerable<CostToAttend> GetTestCostToAttend()
        {
            var costToAttendList = new List<CostToAttend>();
            
            costToAttendList.Add(new CostToAttend() {
                schoolid = 100654,
                pptug_ef = 0.0622,
                npt4_pub = 13415,
                npt4_priv = 0,
                npt41_pub = 12683,
                npt42_pub = 13292,
                npt43_pub = 16104,
                npt44_pub = 16944,
                npt45_pub = 15416,
                npt41_priv = 0,
                npt42_priv = 0,
                npt43_priv = 0,
                npt44_priv = 0,
                npt45_priv = 0
            });

            costToAttendList.Add(new CostToAttend() {
                schoolid = 100663,
                pptug_ef = 0.2579,
                npt4_pub = 14805,
                npt4_priv = 0,
                npt41_pub = 12361,
                npt42_pub = 13765,
                npt43_pub = 16670,
                npt44_pub = 17096,
                npt45_pub = 17291,
                npt41_priv = 0,
                npt42_priv = 0,
                npt43_priv = 0,
                npt44_priv = 0,
                npt45_priv = 0
            });

            return costToAttendList;
        }

        private IEnumerable<CostToAttendPrivate> GetPrivateCostToAttend()
        {
            var privateCostToAttendList = new List<CostToAttendPrivate>();
            
            privateCostToAttendList.Add(new CostToAttendPrivate() {
                schoolid = 100654,
                pptug_ef = 0.0622,
                npt4_priv = 0,
                npt41_priv = 0,
                npt42_priv = 0,
                npt43_priv = 0,
                npt44_priv = 0,
                npt45_priv = 0
            });

            privateCostToAttendList.Add(new CostToAttendPrivate() {
                schoolid = 100654,
                pptug_ef = 0.0622,
                npt4_priv = 0,
                npt41_priv = 0,
                npt42_priv = 0,
                npt43_priv = 0,
                npt44_priv = 0,
                npt45_priv = 0
            });

            return privateCostToAttendList;
        }
    }
}