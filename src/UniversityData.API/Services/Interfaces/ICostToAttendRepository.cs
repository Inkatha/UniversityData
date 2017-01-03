using System.Collections.Generic;
using UniversityData.Models;

namespace UniversityData.Services.Interfaces
{
    public interface ICostToAttendRepository
    {
        IEnumerable<CostToAttend> GetAllCostToAttend();
        CostToAttend GetSchoolCostToAttend(int schoolId);
    }
}