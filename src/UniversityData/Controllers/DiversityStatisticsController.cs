using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAllDiversityStatistics()
        {
            var result = await _diversityStatisticsRepository.GetAllDiversityStatisticsAsync();
            return Ok(result);
        }

        // GET: api/diversitystatitics/{schoolId}
        [HttpGet("{schoolId}")]
        public async Task<IActionResult> GetSchoolDiverisityStatistics(int schoolId)
        {
            var result = await _diversityStatisticsRepository.GetSchoolDiversityStatisticsAsync(schoolId);
            return Ok(result);
        }
    }
}