using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityData.Models;

namespace UniversityData.Services.Interfaces
{
    public interface IStudentLoanDebtsRepository
    {
        Task<IEnumerable<StudentLoanDebts>> GetAllStudentLoanDebtsAsync();
        Task<StudentLoanDebts> GetSchoolStudentLoanDebtsAsync(int schoolId);        
    }
}