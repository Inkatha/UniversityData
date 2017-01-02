using System.Collections.Generic;
using UniversityData.Models;

namespace UniversityData.Services.Interfaces
{
    public interface IFinancialAidProvidedRepository
    {
        IEnumerable<FinancialAidProvided> GetAllFinancialAidProvided();
        FinancialAidProvided GetSchoolFinancialAidProvided(int schoolId);
    }
}