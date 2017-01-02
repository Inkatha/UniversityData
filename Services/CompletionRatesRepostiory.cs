using System.Collections.Generic;
using System.Linq;
using UniversityData.Models;
using UniversityData.Services.Interfaces;

namespace UniversityData.Services
{
    public class CompletionRatesRepository : ICompletionRatesRepository
    {
        private readonly UniversityContext _context;
        public CompletionRatesRepository(UniversityContext context)
        {
            _context = context;
        }

        public IEnumerable<CompletionRates> GetAllCompletionRates()
        {
            return _context.completionrates.ToList();
        }

        public CompletionRates GetSchoolCompletionRates(int schoolId)
        {
            return _context.completionrates.FirstOrDefault(c => c.schoolid == schoolId);
        }
    }
}