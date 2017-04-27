using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UniversityData.Services.Interfaces;
using System;
using Microsoft.Extensions.Logging;
using UniversityData.Constants;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class CompletionRatesController : Controller
    {
        private readonly ICompletionRatesRepository _completionRatesRepository;
        private readonly IBasicInfoRepository _basicInfoRepository;
        private readonly ILogger<CompletionRatesController> _logger;
        public CompletionRatesController(
            ICompletionRatesRepository completionRatesRepository,
            IBasicInfoRepository basicInfoRepository,
            ILogger<CompletionRatesController> logger)
        {
            _completionRatesRepository = completionRatesRepository;
            _basicInfoRepository = basicInfoRepository;
            _logger = logger;
        }

        // GET: api/completionrates
        [HttpGet]
        public async Task<IActionResult> GetAllCompletionRatesAsync()
        {
            try 
            {
                var results = await _completionRatesRepository.GetAllCompletionRatesAsync();
                if (results == null)
                {
                    _logger.LogWarning($"Unable to get all completion rates.");
                    return NotFound();
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("An error occured while getting all completion rates", ex.StackTrace);
                return StatusCode(500, ErrorMessages.InternalServerError);    
            }
        }

        // GET: api/completionsrates/{schoolid}
        [HttpGet("{schoolId}")]
        public async Task<IActionResult> GetSchoolCompletionRatesAsync(int schoolId)
        {
            try
            {
                var result = await _completionRatesRepository.GetSchoolCompletionRatesAsync(schoolId);
                if (result == null)
                {
                    _logger.LogWarning($"Unable to get completion rates for id: {schoolId}");
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"an error occured while getting id:{schoolId} completion rates", ex.StackTrace);
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }
    }
}