using System.Collections.Generic;
using System.Linq;
using UniversityData.Models;
using UniversityData.Services.Interfaces;

namespace UniversityData.Services
{
    public class InstitutionTypeRepository : IInstitutionTypeRepository
    {
        private readonly UniversityContext _context;
        public InstitutionTypeRepository(UniversityContext context)
        {
            _context = context;
        }

        public IEnumerable<InstitutionType> GetAllInstitutionType()
        {
            return _context.institutiontype.ToList();
        }

        public InstitutionType GetSchoolInstitutionType(int schoolId)
        {
            return _context.institutiontype.FirstOrDefault(c => c.schoolid == schoolId);
        }
    }
}