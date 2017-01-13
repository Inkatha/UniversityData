using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityData.Models;

namespace UniversityData.Services.Interfaces
{
    public interface IRetentionRatesRepository
    {
        Task<IEnumerable<RetentionRates>> GetAllRetentionRatesAsync();
        Task<RetentionRates> GetSchoolRetentionRatesAsync(int schoolId);
    }
}