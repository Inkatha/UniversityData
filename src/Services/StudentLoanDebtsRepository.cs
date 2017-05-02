using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityData.Database;
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

        public async Task<IEnumerable<StudentLoanDebts>> GetAllStudentLoanDebtsAsync()
        {
            var result = await _context.studentloandebts.ToListAsync();
            return result;
        }

        public async Task<StudentLoanDebts> GetSchoolStudentLoanDebtsAsync(int schoolId)
        {
            var result = await _context.studentloandebts.FirstOrDefaultAsync(c => c.schoolid == schoolId);
            return result;
        }
    }
}