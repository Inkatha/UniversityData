using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityData.Models;

namespace UniversityData.Services.Interfaces
{
    public interface ICostToAttendRepository
    {
        Task<IEnumerable<CostToAttend>> GetAllCostToAttendAsync();
        Task<CostToAttend> GetSchoolCostToAttendAsync(int schoolId);
    }
}