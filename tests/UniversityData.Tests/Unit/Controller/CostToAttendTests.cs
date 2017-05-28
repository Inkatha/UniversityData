using System;
using Microsoft.Extensions.Logging;
using Moq;
using UniversityData.Controllers;
using UniversityData.Services.Interfaces;
using Xunit;

namespace UniversityData.Tests.Unit.Controller
{
    public class CostToAttendTests
    {
        [Fact]
        public void ShouldReturnNotFoundIfSchoolIdIsNotFound()
        {
            var mockRepo = GetMockRepository();
            var mockLogger = GetMockLogger();
            var controller = new CostToAttendController(mockRepo.Object, mockLogger.Object);
        }

        private Mock<ILogger<CostToAttendController>> GetMockLogger()
        {
            var mockLogger = new Mock<ILogger<CostToAttendController>>();
            return mockLogger;
        }

        private Mock<ICostToAttendRepository> GetMockRepository()
        {
            throw new NotImplementedException();
        }
    }
}