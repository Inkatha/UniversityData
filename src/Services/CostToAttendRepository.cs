using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityData.BindingModels.CostToAttend;
using UniversityData.Models;
using UniversityData.Database;
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

        public async Task<IEnumerable<CostToAttend>> GetSchoolCostOfPrivateSchoolByIncome(int familyIncome)
        {
            // Get all universities whos private net price is greater than zero.
            var result = await _context.costtoattend.Where(c => c.npt4_priv > 0).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<CostToAttend>> GetSchoolCostOfPublicSchoolByIncome(int familyIncome)
        {
            // Get all universities whos public net price is greater than zero.
            var result = await _context.costtoattend.Where(c => c.npt4_pub > 0).ToListAsync();
            return result;
        }
    }
}