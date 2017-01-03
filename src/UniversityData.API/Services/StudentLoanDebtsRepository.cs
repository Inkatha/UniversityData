using System;
using System.Collections.Generic;
using System.Linq;
using UniversityData.Models;
using UniversityData.Services.Interfaces;

namespace UniversityData.Services
{
    public class StudentLoanDebtsRepository : IStudentLoanDebtsRepository
    {
        private readonly UniversityContext _context;
        public StudentLoanDebtsRepository(UniversityContext context)
        {
            _context = context;
        }

        public IEnumerable<StudentLoanDebts> GetAllStudentLoanDebts()
        {
            return _context.studentloandebts.ToList();
        }

        public StudentLoanDebts GetSchoolStudentLoanDebts(int schoolId)
        {
            return _context.studentloandebts.FirstOrDefault(c => c.schoolid == schoolId);
        }
    }
}