using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityData.Models;

namespace UniversityData.Services.Interfaces
{
    public interface IDiversityStatisticsRepository
    {
        Task<IEnumerable<DiversityStatistics>> GetAllDiversityStatisticsAsync();
        Task<DiversityStatistics> GetSchoolDiversityStatisticsAsync(int schoolId);
    }
}