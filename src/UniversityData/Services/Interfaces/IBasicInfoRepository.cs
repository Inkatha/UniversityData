using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityData.Models;

namespace UniversityData.Services.Interfaces
{
    public interface IBasicInfoRepository
    {
        Task<IEnumerable<BasicInfo>> GetAllBasicInformation();
        Task<BasicInfo> GetSchoolBasicInformation(int unitId);
        Task<string> GetSchoolName(int unitId);
        Task<string> GetSchoolUrl(int unitId);
        Task<bool> SchoolExists(int unitId);
    }
}
