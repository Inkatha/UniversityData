using System.Collections.Generic;
using UniversityData.Models;

namespace UniversityData.Services.Interfaces
{
    public interface ICompletionRatesRepository
    {
        IEnumerable<CompletionRates> GetAllCompletionRates();
        CompletionRates GetSchoolCompletionRates(int schoolId);
    }
}