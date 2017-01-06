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
        public IActionResult GetAllEarningsAfterGraduation()
        {
            var earningsAfterGraduationResult = _earningsAfterGraduationRepository.GetAllEarningsAfterGraduation();
            return Ok(earningsAfterGraduationResult); 
        }

        // GET: api/earningsaftergraduation/{schoolid}
        [HttpGet("{schoolId}")]
        public IActionResult GetSchoolEarningsAfterGraduation(int schoolId)
        {
            var earningsaftergraduation = _earningsAfterGraduationRepository.GetSchoolEarningsAfterGraduation(schoolId);
            return Ok(earningsaftergraduation);
        }
    }
}