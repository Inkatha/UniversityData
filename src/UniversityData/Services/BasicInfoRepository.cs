using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<BasicInfo> GetAllBasicInformation()
        {
            return _context.basicinfo.OrderBy(c => c.unitid).ToList();
        }

        public BasicInfo GetSchoolBasicInformation(int unitId)
        {
            return _context.basicinfo.FirstOrDefault(c => c.unitid == unitId);
        }

        public string GetSchoolName(int unitId)
        {
            return _context.basicinfo.FirstOrDefault(c => c.unitid == unitId).instnm;
        }

        public bool SchoolExists(int unitId)
        {
            return _context.basicinfo.Any(c => c.unitid == unitId);
        }
    }
}