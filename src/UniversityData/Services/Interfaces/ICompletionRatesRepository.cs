using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityData.Models;

namespace UniversityData.Services.Interfaces
{
    public interface ICompletionRatesRepository
    {
        Task<IEnumerable<CompletionRates>> GetAllCompletionRatesAsync();
        Task<CompletionRates> GetSchoolCompletionRatesAsync(int schoolId);
    }
}