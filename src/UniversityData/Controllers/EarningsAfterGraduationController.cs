using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class EarningsAfterGraduationController : Controller
    {
        private readonly IEarningsAfterGraduationRepository _earningsAfterGraduationRepository;
        public EarningsAfterGraduationController(IEarningsAfterGraduationRepository earningsAfterGraduationRepository)
        {
            _earningsAfterGraduationRepository = earningsAfterGraduationRepository;
        }

        // GET: api/earningsaftergraduation
        [HttpGet]
        public async Task<IActionResult> GetAllEarningsAfterGraduationAsync()
        {
            var result = await _earningsAfterGraduationRepository.GetAllEarningsAfterGraduationAsync();
            return Ok(result); 
        }

        // GET: api/earningsaftergraduation/{schoolid}
        [HttpGet("{schoolId}")]
        public async Task<IActionResult> GetSchoolEarningsAfterGraduationAsync(int schoolId)
        {
            var result = await _earningsAfterGraduationRepository.GetSchoolEarningsAfterGraduationAsync(schoolId);
            return Ok(result);
        }
    }
}