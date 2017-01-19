using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UniversityData.Services.Interfaces;
using System;
using Microsoft.Extensions.Logging;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class CompletionRatesController : Controller
    {
        private readonly ICompletionRatesRepository _completionRatesRepository;
        private readonly IBasicInfoRepository _basicInfoRepository;
        private readonly ILogger _logger;
        public CompletionRatesController(
            ICompletionRatesRepository completionRatesRepository,
            IBasicInfoRepository basicInfoRepository,
            ILogger logger)
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
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("An error occured while handling your request:", ex);
                return StatusCode(500, "An error occured");    
            }
        }

        // GET: api/completionsrates/{schoolid}
        [HttpGet("{schoolId}")]
        public async Task<IActionResult> GetSchoolCompletionRatesAsync(int schoolId)
        {
            try
            {
                if (await _basicInfoRepository.SchoolExistsAsync(schoolId) == false)
                {
                    _logger.LogWarning($"A school with the id: {schoolId} does not exist.");
                    return NotFound();
                }
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
                _logger.LogCritical("an error occured: ", ex);
                return StatusCode(500, "An error occured.");
            }
        }
    }
}