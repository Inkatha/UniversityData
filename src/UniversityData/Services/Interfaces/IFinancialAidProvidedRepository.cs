using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityData.Models;

namespace UniversityData.Services.Interfaces
{
    public interface IFinancialAidProvidedRepository
    {
        Task<IEnumerable<FinancialAidProvided>> GetAllFinancialAidProvidedAsync();
        Task<FinancialAidProvided> GetSchoolFinancialAidProvidedAsync(int schoolId);
    }
}