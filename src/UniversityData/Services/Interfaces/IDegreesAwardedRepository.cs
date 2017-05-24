using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityData.Models;

namespace UniversityData.Services.Interfaces
{
    public interface IDegreesAwardedRepository
    {
        Task<IEnumerable<DegreesAwarded>> GetAllDegreesAwardedAsync();
        Task<DegreesAwarded> GetSchoolDegreesAwardedAsync(int schoolId);
    }
}