using System.Collections.Generic;
using System.Linq;
using UniversityData.Models;
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

        public IEnumerable<FinancialAidProvided> GetAllFinancialAidProvided()
        {
            return _context.financialaidprovided.ToList();
        }

        public FinancialAidProvided GetSchoolFinancialAidProvided(int schoolId)
        {
            return _context.financialaidprovided.FirstOrDefault(c => c.schoolid == schoolId);
        }
    }
}