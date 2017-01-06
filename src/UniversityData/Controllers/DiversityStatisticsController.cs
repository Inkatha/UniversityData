using Microsoft.AspNetCore.Mvc;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class DiversityStatisticsController : Controller
    {
        private readonly IDiversityStatisticsRepository _diversityStatisticsRepository;
        public DiversityStatisticsController(IDiversityStatisticsRepository diversityStatisticsRepository)
        {
            _diversityStatisticsRepository = diversityStatisticsRepository;
        }

        // GET: api/diversitystatitics
        [HttpGet]
        public IActionResult GetAllDiversityStatistics()
        {
            var diversityStatisticsResult = _diversityStatisticsRepository.GetAllDiversityStatistics();
            return Ok(diversityStatisticsResult);
        }

        // GET: api/diversitystatitics/{schoolId}
        [HttpGet("{schoolId}")]
        public IActionResult GetSchoolDiverisityStatistics(int schoolId)
        {
            var diversityStatiticsResult = _diversityStatisticsRepository.GetSchoolDiversityStatistics(schoolId);
            return Ok(diversityStatiticsResult);
        }
    }
}