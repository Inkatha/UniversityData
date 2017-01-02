using System.Collections.Generic;
using System.Linq;
using UniversityData.Models;
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
        public IEnumerable<EarningsAfterGraduation> GetAllEarningsAfterGraduation()
        {
            return _context.earningsaftergraduation.ToList();
        }
        public EarningsAfterGraduation GetSchoolEarningsAfterGraduation(int schoolId)
        {
            return _context.earningsaftergraduation.FirstOrDefault(c => c.schoolid == schoolId);
        }
    }
}