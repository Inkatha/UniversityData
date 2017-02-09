using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityData.Models;
using UniversityData.Services.Interfaces;

namespace UniversityData.Services
{
    public class BasicInfoRepository : IBasicInfoRepository
    {
        private readonly UniversityContext _context;

        public BasicInfoRepository(UniversityContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BasicInfo>> GetAllBasicInformationAsync()
        {
            var result = await _context.basicinfo.OrderBy(c => c.unitid).ToListAsync();
            return result;
        }

        public async Task<BasicInfo> GetSchoolBasicInformationAsync(int unitId)
        {
            var result = await _context.basicinfo.FirstOrDefaultAsync(c => c.unitid == unitId);
            return result;
        }

        public async Task<string> GetSchoolNameAsync(int unitId)
        {
            var result = await GetSchoolBasicInformationAsync(unitId);
            return result.instnm;
        }

        public async Task<string> GetSchoolUrlAsync(int unitId)
        {
            var result = await GetSchoolBasicInformationAsync(unitId);
            return result.insturl;
        }

        public async Task<bool> SchoolExistsAsync(int unitId)
        {
            var result = await _context.basicinfo.AnyAsync(c => c.unitid == unitId);
            return result;
        }
    }
}