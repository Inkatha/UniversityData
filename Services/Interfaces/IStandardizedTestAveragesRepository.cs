using System.Collections.Generic;
using UniversityData.Models;

namespace UniversityData.Services.Interfaces
{
    public interface IStandardizedTestAveragesRepository
    {
        IEnumerable<StandardizedTestAverages> GetAllStandardizedTestAverages();
        StandardizedTestAverages GetSchoolStandardizedTestAverages(int schoolId);
    }
}