using System.Collections.Generic;
using System.Linq;
using UniversityData.Models;
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

        public IEnumerable<DiversityStatistics> GetAllDiversityStatistics()
        {
            return _context.diversitystatistics.ToList();
        }

        public DiversityStatistics GetSchoolDiversityStatistics(int schoolId)
        {
            return _context.diversitystatistics.FirstOrDefault(c => c.schoolid == schoolId);
        }
    }
}