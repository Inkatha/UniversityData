using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<RetentionRates> GetAllRetentionRates()
        {
            return _context.retentionrates.ToList();
        }

        public RetentionRates GetSchoolRetentionRates(int schoolId)
        {
            return _context.retentionrates.FirstOrDefault(c => c.schoolid == schoolId);
        }
    }
}