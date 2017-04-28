using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniversityData.Constants;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class EarningsAfterGraduationController : Controller
    {
        private readonly IEarningsAfterGraduationRepository _earningsAfterGraduationRepository;
        private readonly ILogger<EarningsAfterGraduationController> _logger;
        public EarningsAfterGraduationController(
            IEarningsAfterGraduationRepository earningsAfterGraduationRepository,
            ILogger<EarningsAfterGraduationController> logger)
        {
            _earningsAfterGraduationRepository = earningsAfterGraduationRepository;
            _logger = logger;
        }

        // GET: api/earningsaftergraduation
        [HttpGet]
        public async Task<IActionResult> GetAllEarningsAfterGraduationAsync()
        {
            try
            {
                var results = await _earningsAfterGraduationRepository.GetAllEarningsAfterGraduationAsync();
                if (results == null)
                {
                    _logger.LogWarning("Unable to get all earnings after graduation");
                    NotFound();
                }
                return Ok(results); 
            }
            catch (Exception ex)
            {
                _logger.LogCritical("An error occured while getting all earnings after graduation.", ex.StackTrace);
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
           
        }

        // GET: api/earningsaftergraduation/{schoolid}
        [HttpGet("{schoolId}")]
        public async Task<IActionResult> GetSchoolEarningsAfterGraduationAsync(int schoolId)
        {
            try 
            {
                var result = await _earningsAfterGraduationRepository.GetSchoolEarningsAfterGraduationAsync(schoolId);
                if (result == null)
                {
                    _logger.LogWarning($"Unable to get earnings after graduation for id:{schoolId}");
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("An error occured while getting a school's earnings after graduation.", ex.StackTrace);
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }
    }
}