using Moq;
using Xunit;
using UniversityData.Services.Interfaces;
using UniversityData.Controllers;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using UniversityData.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace UniversityData.Tests.Unit.Controller
{
    public class BasicInfoControllerTests
    {
        [Fact]
        public void ShouldReturnNotFoundIfSchoolIdIsNotFound()
        {
            // Arrange
            int unitId = 999999999;
            var mockRepo = GetSchoolRepositoryMock(unitId);
            var mockLogger = GetLoggerMock();
            var controller = new BasicInfoController(mockRepo.Object, mockLogger.Object);

            // Act
            var actionResult = controller.GetSchoolInformationAsync(unitId).Result;

            // Assert
            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Fact]
        public void ShouldReturnOkIfSchoolIdIsFound()
        {
            // Arrange
            int unitId = 100663;
            var mockRepo = GetSchoolRepositoryMock(unitId);
            var mockLogger = GetLoggerMock();
            var controller = new BasicInfoController(mockRepo.Object, mockLogger.Object);

            // Act
            var actionResult = controller.GetSchoolInformationAsync(unitId).Result;

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public void ShouldFailIfOnlyNameIsNotReturned()
        {
            // Arrange
            int unitId = 100663;
            var mockRepo = GetSchoolNameRepositoryMock(unitId);
            var mockLogger = GetLoggerMock();
            var controller = new BasicInfoController(mockRepo.Object, mockLogger.Object);

            // Act
            var result = controller.GetSchoolName(unitId).Result;

            // Assert
            var nameOfFoundSchool = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("University of Alabama at Birmingham", nameOfFoundSchool.Value);
        }

        [Fact]
        public void ShouldFailIfOnlyUrlIsNotReturned()
        {
            // Arrange
            int unitId = 100663;
            var mockRepo = GetSchoolUrlRepositoryMock(unitId);
            var mockLogger = GetLoggerMock();
            var controller = new BasicInfoController(mockRepo.Object, mockLogger.Object);

            // Act
            var result = controller.GetSchoolUrl(unitId).Result;

            // Assert
            var urlOfFoundSchool = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("www.uab.edu", urlOfFoundSchool.Value);
        }

        private Mock<IBasicInfoRepository> GetSchoolRepositoryMock(int unitId)
        {
            var mockRepo = new Mock<IBasicInfoRepository>();

            mockRepo.Setup(repo =>
                repo.GetSchoolBasicInformationAsync(unitId)
            ).Returns(Task.FromResult(GetTestBasicInfo()
             .FirstOrDefault(s => s.unitid == unitId)));

            return mockRepo;
        }
        
        private Mock<IBasicInfoRepository> GetSchoolNameRepositoryMock(int unitId)
        {
            var mockRepo = new Mock<IBasicInfoRepository>();

            mockRepo.Setup(repo =>
                repo.GetSchoolNameAsync(unitId)
            ).Returns(Task.FromResult(GetTestBasicInfo()
             .FirstOrDefault(s => s.unitid == unitId).instnm));

            return mockRepo;
        }

        private Mock<IBasicInfoRepository> GetSchoolUrlRepositoryMock(int unitId)
        {
            var mockRepo = new Mock<IBasicInfoRepository>();

            mockRepo.Setup(repo => 
                repo.GetSchoolUrlAsync(unitId)
            ).Returns(Task.FromResult(GetTestBasicInfo()
             .FirstOrDefault(s => s.unitid == unitId).insturl));

            return mockRepo;
        }


        private Mock<ILogger<BasicInfoController>> GetLoggerMock()
        {
            var mockLogger = new Mock<ILogger<BasicInfoController>>();
            return mockLogger;
        }

        private IEnumerable<BasicInfo> GetTestBasicInfo()
        {
            var basicInfoList = new List<BasicInfo>();

            basicInfoList.Add(new BasicInfo()
            {
                unitid  = 100654,
                opeid   = 100200,
                opeid6  = 1002,
                instnm  = "Alabama A & M University",
                city    = "Normal",
                stabbr  = "AL",
                insturl = "www.aamu.edu",
                npcurl  = "galileo.aamu.edu/netpricecalculator/npcalc.htm"
            });

            basicInfoList.Add(new BasicInfo()
            {
                unitid = 100663,
                opeid = 105200,
                opeid6 = 1052,
                instnm = "University of Alabama at Birmingham",
                city = "Birmingham",
                stabbr = "AL",
                insturl = "www.uab.edu",
                npcurl = "www.collegeportraits.org/AL/UAB/estimator/agree"
            });

            return basicInfoList;
        }
    }
}