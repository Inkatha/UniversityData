using System.Collections.Generic;
using UniversityData.Models;

namespace UniversityData.Services.Interfaces
{
    public interface IDiversityStatisticsRepository
    {
        IEnumerable<DiversityStatistics> GetAllDiversityStatistics();

        DiversityStatistics GetSchoolDiversityStatistics(int schoolId);
    }
}