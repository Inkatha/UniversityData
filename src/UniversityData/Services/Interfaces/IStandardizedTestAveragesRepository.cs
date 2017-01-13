using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityData.Models;

namespace UniversityData.Services.Interfaces
{
    public interface IStandardizedTestAveragesRepository
    {
        Task<IEnumerable<StandardizedTestAverages>> GetAllStandardizedTestAveragesAsync();
        Task<StandardizedTestAverages> GetSchoolStandardizedTestAveragesAsync(int schoolId);
    }
}