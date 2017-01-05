using Microsoft.AspNetCore.Mvc;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class DiversityStatisticsController : Controller
    {
        private readonly IDiversityStatisticsRepository _repository;
        public DiversityStatisticsController(IDiversityStatisticsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/diversitystatitics
        [HttpGet]
        public IActionResult GetAllDiversityStatistics()
        {
            var diversityStatisticsResult = _repository.GetAllDiversityStatistics();
            return Ok(diversityStatisticsResult);
        }

        // GET: api/diversitystatitics/{schoolId}
        [HttpGet("{schoolId}")]
        public IActionResult GetSchoolDiverisityStatistics(int schoolId)
        {
            var diversityStatiticsResult = _repository.GetSchoolDiversityStatistics(schoolId);
            return Ok(diversityStatiticsResult);
        }
    }
}