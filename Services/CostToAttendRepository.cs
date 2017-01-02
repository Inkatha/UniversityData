using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<CostToAttend> GetAllCostToAttend()
        {
            return _context.costtoattend.ToList();
        }

        public CostToAttend GetSchoolCostToAttend(int schoolId)
        {
            return _context.costtoattend.FirstOrDefault(c => c.schoolid == schoolId);
        }
    }
}