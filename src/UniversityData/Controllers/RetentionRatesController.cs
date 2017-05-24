using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniversityData.Constants;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class RetentionRatesController : Controller
    {
        private readonly IRetentionRatesRepository _retentionRatesRepository;
        private readonly ILogger<RetentionRatesController> _logger;
        public RetentionRatesController(
            IRetentionRatesRepository retentionRatesRepository,
            ILogger<RetentionRatesController> logger)
        {  
            _retentionRatesRepository = retentionRatesRepository;
            _logger = logger;
        }

        // GET: api/retentionrates
        [HttpGet]
        public async Task<IActionResult> GetAllRetentionRatesAsync()
        {
            try
            {
                var results = await _retentionRatesRepository.GetAllRetentionRatesAsync();
                if (results == null)
                {
                    _logger.LogWarning("Unable to get all retention rates");
                    return NotFound();
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("An error occured while getting all retention rates", ex.StackTrace);
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }

        // GET: api/retentionrates/{schoolId}
        [HttpGet("{schoolId}")]
        public async Task<IActionResult> GetSchoolRetentionRates(int schoolId)
        {
            try 
            {
                var result = await _retentionRatesRepository.GetSchoolRetentionRatesAsync(schoolId);
                if (result == null)
                {
                    _logger.LogWarning($"Unable to get retention rates for id:{schoolId}.");
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("An error occured while getting id:{schoolId} retention rates.",ex.StackTrace);
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }
    }
}