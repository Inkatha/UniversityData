using Microsoft.AspNetCore.Mvc;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class StudentLoanDebtsController : Controller
    {
        private readonly IStudentLoanDebtsRepository _studentLoanDebtsRepository;
        public StudentLoanDebtsController(IStudentLoanDebtsRepository studentLoanDebtsRepository)
        {
            _studentLoanDebtsRepository = studentLoanDebtsRepository;
        }

        // GET: api/studentloandebts
        [HttpGet]
        public IActionResult GetAllStudentLoanDebts()
        {
            var studentLoanDebtResults = _studentLoanDebtsRepository.GetAllStudentLoanDebts();
            return Ok(studentLoanDebtResults);
        }

        // GET: api/studentloandebts/{schoolId}
        [HttpGet("{schoolId}")]
        public IActionResult GetSchoolStudentLoanDebts(int schoolId)
        {
            var studentLoanDebtResult = _studentLoanDebtsRepository.GetSchoolStudentLoanDebts(schoolId);
            return Ok(studentLoanDebtResult);
        }
    }
}