using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityData.Models;
using UniversityData.Database;
using UniversityData.Services.Interfaces;

namespace UniversityData.Services
{
    public class DegreesAwardedRepository : IDegreesAwardedRepository
    {
        private readonly UniversityContext _context;
        public DegreesAwardedRepository(UniversityContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<DegreesAwarded>> GetAllDegreesAwardedAsync()
        {
            var result = await _context.degreesawarded.ToListAsync();
            return result;
        }

        public async Task<DegreesAwarded> GetSchoolDegreesAwardedAsync(int schoolId)
        {
            var result = await _context.degreesawarded.FirstOrDefaultAsync(c => c.schoolid == schoolId);
            return result;
        }
    }
}