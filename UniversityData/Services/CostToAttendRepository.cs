using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityData.Models;
using UniversityData.Services.Interfaces;

namespace UniversityData.Services
{
    public class CostToAttendRepository : ICostToAttendRepository
    {
        private readonly UniversityContext _context;

        public CostToAttendRepository(UniversityContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CostToAttend>> GetAllCostToAttendAsync()
        {
            var result = await _context.costtoattend.ToListAsync();
            return result;
        }

        public async Task<CostToAttend> GetSchoolCostToAttendAsync(int schoolId)
        {
            var result = await _context.costtoattend.FirstOrDefaultAsync(c => c.schoolid == schoolId); 
            return result;
        }
    }
}