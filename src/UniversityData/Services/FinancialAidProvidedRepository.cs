using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityData.Models;
using UniversityData.Database;
using UniversityData.Services.Interfaces;

namespace UniversityData.Services
{
    public class FinancialAidProvidedRepository : IFinancialAidProvidedRepository
    {
        private readonly UniversityContext _context;
        public FinancialAidProvidedRepository(UniversityContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FinancialAidProvided>> GetAllFinancialAidProvidedAsync()
        {
            var result = await _context.financialaidprovided.ToListAsync();
            return result;
        }

        public async Task<FinancialAidProvided> GetSchoolFinancialAidProvidedAsync(int schoolId)
        {
            var result = await _context.financialaidprovided.FirstOrDefaultAsync(c => c.schoolid == schoolId);
            return result;
        }
    }
}