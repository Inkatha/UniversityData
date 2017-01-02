using System.Collections.Generic;
using UniversityData.Models;

namespace UniversityData.Services.Interfaces
{
    public interface IStudentLoanDebtsRepository
    {
        IEnumerable<StudentLoanDebts> GetAllStudentLoanDebts();
        StudentLoanDebts GetSchoolStudentLoanDebts(int schoolId);        
    }
}