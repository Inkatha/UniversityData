using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using UniversityData.Models;

namespace UniversityData.Services.Interfaces
{
    public interface IBasicInfoRepository
    {
        Task<IEnumerable<BasicInfo>> GetAllBasicInformationAsync();
        Task<BasicInfo> GetSchoolBasicInformationAsync(int unitId);
        Task<string> GetSchoolNameAsync(int unitId);
        Task<string> GetSchoolUrlAsync(int unitId);
        Task<bool> SchoolExistsAsync(int unitId);
        Task<string> SchoolSearchAsync(string searchTerm);
    }
}
