using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityData.Models;
using UniversityData.Services.Interfaces;

namespace UniversityData.Services
{
    public class RetentionRatesRepository : IRetentionRatesRepository
    {
        private readonly UniversityContext _context;
        public RetentionRatesRepository(UniversityContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RetentionRates>> GetAllRetentionRatesAsync()
        {
            var result = await _context.retentionrates.ToListAsync();
            return result;
        }

        public async Task<RetentionRates> GetSchoolRetentionRatesAsync(int schoolId)
        {
            var result = await _context.retentionrates.FirstOrDefaultAsync(c => c.schoolid == schoolId);
            return result;
        }
    }
}