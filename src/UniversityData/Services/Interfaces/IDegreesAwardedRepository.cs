using System.Collections.Generic;
using UniversityData.Models;

namespace UniversityData.Services.Interfaces
{
    public interface IDegreesAwardedRepository
    {
        IEnumerable<DegreesAwarded> GetAllDegreesAwarded();
        DegreesAwarded GetSchoolDegreesAwarded(int schoolId);
    }
}