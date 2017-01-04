using Microsoft.AspNetCore.Mvc;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class EarningsAfterGraduationController : Controller
    {
        private readonly IEarningsAfterGraduationRepository _repository;
        public EarningsAfterGraduationController(IEarningsAfterGraduationRepository repository)
        {
            _repository = repository;
        }

        // GET: api/earningsaftergraduation
        [HttpGet]
        public IActionResult GetAllEarningsAfterGraduation()
        {
            var earningsAfterGraduationResult = _repository.GetAllEarningsAfterGraduation();
            return Ok(earningsAfterGraduationResult); 
        }

        // GET: api/earningsaftergraduation/{schoolid}
        [HttpGet("{schoolId}")]
        public IActionResult GetSchoolEarningsAfterGraduation(int schoolId)
        {
            var earningsaftergraduation = _repository.GetSchoolEarningsAfterGraduation(schoolId);
            return Ok(earningsaftergraduation);
        }
    }
}