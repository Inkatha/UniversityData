using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniversityData.Constants;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class DiversityStatisticsController : Controller
    {
        private readonly IDiversityStatisticsRepository _diversityStatisticsRepository;
        private readonly ILogger<DiversityStatisticsController> _logger;
        public DiversityStatisticsController(
            IDiversityStatisticsRepository diversityStatisticsRepository,
            ILogger<DiversityStatisticsController> logger)
        {
            _diversityStatisticsRepository = diversityStatisticsRepository;
            _logger = logger;
        }

        // GET: api/diversitystatitics
        [HttpGet]
        public async Task<IActionResult> GetAllDiversityStatistics()
        {
            try 
            {
                var results = await _diversityStatisticsRepository.GetAllDiversityStatisticsAsync();
                if (results == null)
                {
                    _logger.LogWarning($"Unable to get all diversity statistics.");
                    return NotFound();
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("An error occured while getting all diversity statistics: ", ex.StackTrace);
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }

        // GET: api/diversitystatitics/{schoolId}
        [HttpGet("{schoolId}")]
        public async Task<IActionResult> GetSchoolDiverisityStatistics(int schoolId)
        {
            try 
            {
                var result = await _diversityStatisticsRepository.GetSchoolDiversityStatisticsAsync(schoolId);
                if (result == null)
                {
                    _logger.LogWarning($"Unable to get diversity statistics for id:{schoolId}.");
                    return NotFound();
                }
                return Ok(result);    
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"An error occured while getting {schoolId} diversity statistics. ", ex.StackTrace);    
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }
    }
}