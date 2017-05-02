using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityData.Models;
using UniversityData.Database;
using UniversityData.Services.Interfaces;

namespace UniversityData.Services
{
    public class StandardizedTestAveragesRepository : IStandardizedTestAveragesRepository
    {
        private readonly UniversityContext _context;

        public StandardizedTestAveragesRepository(UniversityContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StandardizedTestAverages>> GetAllStandardizedTestAveragesAsync()
        {
            var result = await _context.standardizedtestaverages.ToListAsync();
            return result;
        }

        public async Task<StandardizedTestAverages> GetSchoolStandardizedTestAveragesAsync(int schoolId)
        {
            var result = await _context.standardizedtestaverages.FirstOrDefaultAsync(c => c.schoolid == schoolId);
            return result;
        }
    }
}