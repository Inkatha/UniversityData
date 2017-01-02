using Microsoft.AspNetCore.Mvc;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class StudentLoanDebtsController : Controller
    {
        private readonly IStudentLoanDebtsRepository _repository;
        public StudentLoanDebtsController(IStudentLoanDebtsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/studentloandebts
        [HttpGet]
        public IActionResult GetAllStudentLoanDebts()
        {
            var studentLoanDebtResults = _repository.GetAllStudentLoanDebts();
            return Ok(studentLoanDebtResults);
        }

        // GET: api/studentloandebts/{schoolId}
        [HttpGet("{schoolId}")]
        public IActionResult GetSchoolStudentLoanDebts(int schoolId)
        {
            var studentLoanDebtResult = _repository.GetSchoolStudentLoanDebts(schoolId);
            return Ok(studentLoanDebtResult);
        }
    }
}