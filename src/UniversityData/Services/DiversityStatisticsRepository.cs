using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityData.Models;
using UniversityData.Database;
using UniversityData.Services.Interfaces;

namespace UniversityData.Services
{
    public class DiversityStatisticsRepository : IDiversityStatisticsRepository
    {
        private readonly UniversityContext _context;

        public DiversityStatisticsRepository(UniversityContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DiversityStatistics>> GetAllDiversityStatisticsAsync()
        {
            var result = await _context.diversitystatistics.ToListAsync();
            return result;
        }

        public async Task<DiversityStatistics> GetSchoolDiversityStatisticsAsync(int schoolId)
        {
            var result = await _context.diversitystatistics.FirstOrDefaultAsync(c => c.schoolid == schoolId);
            return result;
        }
    }
}