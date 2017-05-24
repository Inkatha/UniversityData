using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityData.Models;
using UniversityData.Database;
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

        public async Task<IEnumerable<InstitutionType>> GetAllInstitutionTypeAsync()
        {
            var result = await _context.institutiontype.ToListAsync();
            return result;
        }

        public async Task<InstitutionType> GetSchoolInstitutionTypeAsync(int schoolId)
        {
            var result = await _context.institutiontype.FirstOrDefaultAsync(c => c.schoolid == schoolId);
            return result;
        }
    }
}