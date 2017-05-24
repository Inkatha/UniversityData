using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityData.Models;
using UniversityData.Database;
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
        public async Task<IEnumerable<CompletionRates>> GetAllCompletionRatesAsync()
        {
            var result = await _context.completionrates.ToListAsync();
            return result;
        }

        public async Task<CompletionRates> GetSchoolCompletionRatesAsync(int schoolId)
        {
            var result = await _context.completionrates.FirstOrDefaultAsync(c => c.schoolid == schoolId);
            return result;
        }
    }
}