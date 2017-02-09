using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityData.Models;

namespace UniversityData.Services.Interfaces
{
    public interface IInstitutionTypeRepository
    {
        Task<IEnumerable<InstitutionType>> GetAllInstitutionTypeAsync();
        Task<InstitutionType> GetSchoolInstitutionTypeAsync(int schoolId);
    } 
}