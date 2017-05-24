using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityData.Models;
using UniversityData.Database;
using UniversityData.Services.Interfaces;

namespace UniversityData.Services
{
    public class EarningsAfterGraduationRepository : IEarningsAfterGraduationRepository
    {
        private readonly UniversityContext _context;
        public EarningsAfterGraduationRepository(UniversityContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<EarningsAfterGraduation>> GetAllEarningsAfterGraduationAsync()
        {
            var result = await _context.earningsaftergraduation.ToListAsync();
            return result;
        }
        public async Task<EarningsAfterGraduation> GetSchoolEarningsAfterGraduationAsync(int schoolId)
        {
            var result = await _context.earningsaftergraduation.FirstOrDefaultAsync(c => c.schoolid == schoolId);
            return result;
        }
    }
}