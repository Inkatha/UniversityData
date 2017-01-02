using System.Collections.Generic;
using UniversityData.Models;

namespace UniversityData.Services.Interfaces
{
    public interface IBasicInfoRepository
    {
        IEnumerable<BasicInfo> GetAllBasicInformation();
        BasicInfo GetSchoolBasicInformation(int unitId);
        bool SchoolExists(int unitId);
    }
}
