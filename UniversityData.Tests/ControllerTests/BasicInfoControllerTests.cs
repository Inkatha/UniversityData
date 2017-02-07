using System;
using System.Collections;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UniversityData.Tests
{
    [TestFixture]
    public class BasicControllerTests : AssertionHelper
    {
        [Test]
        public async Task<ITestAction> GetAllInformationTests()
        {
            var results = await _basicInfoRepository.GetAllBasicInformationAsync();
        }
    }
}