using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityData.BindingModels.CostToAttend;
using UniversityData.Constants;
using UniversityData.Models;

namespace UniversityData.Services.Interfaces
{
    public interface ICostToAttendRepository
    {
        Task<IEnumerable<CostToAttend>> GetAllCostToAttendAsync();
        Task<CostToAttend> GetSchoolCostToAttendAsync(int schoolId);
        Task<IEnumerable<CostToAttend>> GetSchoolCostOfPrivateSchoolByIncome(int familyIncome);
        Task<IEnumerable<CostToAttend>> GetSchoolCostOfPublicSchoolByIncome(int familyIncome);
    }
}