using Moq;
using Xunit;
using UniversityData.Controllers;
using System.Collections.Generic;
using UniversityData.Models;
using UniversityData.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace UniversityData.Tests.Unit.Controller
{
    public class CompletionRatesControllerTest
    {
        [Fact]
        public void ShouldReturnNotFoundIfSchoolIdIsNotFound()
        {
            // Arrange
            var unitId = 999999999;
            var mockRepo = GetMockRepository(unitId);
            var mockLogger = GetMockLogger();
            var controller = new CompletionRatesController(mockRepo.Object, mockLogger.Object);

            // Act
            var actionResult = controller.GetSchoolCompletionRatesAsync(unitId).Result;
            
            // Assert
            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Fact]
        public void ShouldReturnOkIfSchoolIsfound()
        {
            // Arrange
            var unitId = 100663;
            var mockRepo = GetMockRepository(unitId);
            var mockLogger = GetMockLogger();
            var controller = new CompletionRatesController(mockRepo.Object, mockLogger.Object);

            // Act
            var actionResult = controller.GetSchoolCompletionRatesAsync(unitId).Result;

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        private IEnumerable<CompletionRates> GetTestCompletionRates()
        {
            var completionRatesList = new List<CompletionRates>();

            completionRatesList.Add(new CompletionRates{
                schoolid = 100663,
                c150_4_pooled_supp = 0.5085498079,
                c200_l4_pooled_supp = 0
            });

            completionRatesList.Add(new CompletionRates{
                schoolid = 100690,
                c150_4_pooled_supp = 0,
                c200_l4_pooled_supp = 0
            });

            return completionRatesList;
        }

        private Mock<ICompletionRatesRepository> GetMockRepository(int unitId)
        {
            var mockRepo = new Mock<ICompletionRatesRepository>();

            mockRepo.Setup(repo => 
                repo.GetSchoolCompletionRatesAsync(unitId)
            ).Returns(Task.FromResult(GetTestCompletionRates()
             .FirstOrDefault(s => s.schoolid == unitId)));

            return mockRepo;
        }

        private Mock<ILogger<CompletionRatesController>> GetMockLogger()
        {
            var mockRepo = new Mock<ILogger<CompletionRatesController>>();
            return mockRepo;
        }
    }
}