using System;
using System.Collections.Generic;
using System.Linq;
using UniversityData.Models;
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
        IEnumerable<DegreesAwarded> IDegreesAwardedRepository.GetAllDegreesAwarded()
        {
            return _context.degreesawarded.ToList();
        }

        DegreesAwarded IDegreesAwardedRepository.GetSchoolDegreesAwarded(int schoolId)
        {
            return _context.degreesawarded.FirstOrDefault(c => c.schoolid == schoolId);
        }
    }
}