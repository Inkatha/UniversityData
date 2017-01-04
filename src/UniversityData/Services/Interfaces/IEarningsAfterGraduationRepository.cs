using System.Collections.Generic;
using UniversityData.Models;

namespace UniversityData.Services.Interfaces
{
    public interface IEarningsAfterGraduationRepository
    {
        IEnumerable<EarningsAfterGraduation> GetAllEarningsAfterGraduation();
        EarningsAfterGraduation GetSchoolEarningsAfterGraduation(int schoolId);
    }
}