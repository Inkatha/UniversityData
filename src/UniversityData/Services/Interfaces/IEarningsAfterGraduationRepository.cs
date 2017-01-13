using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityData.Models;

namespace UniversityData.Services.Interfaces
{
    public interface IEarningsAfterGraduationRepository
    {
        Task<IEnumerable<EarningsAfterGraduation>> GetAllEarningsAfterGraduationAsync();
        Task<EarningsAfterGraduation> GetSchoolEarningsAfterGraduationAsync(int schoolId);
    }
}