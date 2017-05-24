using Xunit;
using UniversityData.Services.Interfaces;

namespace UniversityData.Tests.Services
{
    public class BasicInfoRepositoryTests
    {
        public async void ShouldReturnNullIfSchoolIdIsntFound()
        {
            var sut = new IBasicInfoRepository();

            var result = await sut.GetSchoolBasicInformationAsync(999999);

            Assert.Equal(null, result);
        }        
    }
}