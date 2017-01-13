using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAllStudentLoanDebtsAsync()
        {
            var result = await _studentLoanDebtsRepository.GetAllStudentLoanDebtsAsync();
            return Ok(result);
        }

        // GET: api/studentloandebts/{schoolId}
        [HttpGet("{schoolId}")]
        public async Task<IActionResult> GetSchoolStudentLoanDebtsAsync(int schoolId)
        {
            var result = await _studentLoanDebtsRepository.GetSchoolStudentLoanDebtsAsync(schoolId);
            return Ok(result);
        }
    }
}