using System.Collections.Generic;
using UniversityData.Models;

namespace UniversityData.Services.Interfaces
{
    public interface IInstitutionTypeRepository
    {
        IEnumerable<InstitutionType> GetAllInstitutionType();
        InstitutionType GetSchoolInstitutionType(int schoolId);
    } 
}