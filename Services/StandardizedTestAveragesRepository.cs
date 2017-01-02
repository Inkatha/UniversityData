using System;
using System.Collections.Generic;
using System.Linq;
using UniversityData.Models;
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

        public IEnumerable<StandardizedTestAverages> GetAllStandardizedTestAverages()
        {
            return _context.standardizedtestaverages.ToList();
        }

        public StandardizedTestAverages GetSchoolStandardizedTestAverages(int schoolId)
        {
            return _context.standardizedtestaverages.FirstOrDefault(c => c.schoolid == schoolId);
        }
    }
}