using System.Collections.Generic;
using UniversityData.Models;

namespace UniversityData.Services.Interfaces
{
    public interface IRetentionRatesRepository
    {
        IEnumerable<RetentionRates> GetAllRetentionRates();
        RetentionRates GetSchoolRetentionRates(int schoolId);
    }
}