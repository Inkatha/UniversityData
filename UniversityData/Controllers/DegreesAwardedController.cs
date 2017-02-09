using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniversityData.Constants;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class DegreesAwardedController : Controller
    {
        private readonly IDegreesAwardedRepository _degreesAwardedRepository;
        private readonly IBasicInfoRepository _basicInfoRepository;
        private readonly ILogger<DegreesAwardedController> _logger; 
        public DegreesAwardedController(
            IDegreesAwardedRepository degreesAwardedRepository,
            IBasicInfoRepository basicInfoRepository,
            ILogger<DegreesAwardedController> logger)
        {
            _degreesAwardedRepository = degreesAwardedRepository;
            _basicInfoRepository = basicInfoRepository;
            _logger = logger;
        }

        // GET: api/degreesawarded
        [HttpGet]
        public async Task<IActionResult> GetAllDegreesAwardedAsync()
        {
            try 
            {
                var results = await _degreesAwardedRepository.GetAllDegreesAwardedAsync();
                if (results == null)
                {
                    _logger.LogWarning($"Unable to get all degrees awarded.");
                    return NotFound();
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                Console.WriteLine("an error occured while getting all degrees awarded ", ex.StackTrace);
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }

        // GET: api/degreesawarded/{schoolId}
        [HttpGet("{schoolId}")]
        public async Task<IActionResult> GetSchoolDegreesAwardedAsync(int schoolId)
        {
            try 
            {
                if (await _basicInfoRepository.SchoolExistsAsync(schoolId) == false) 
                {
                    _logger.LogWarning($"Unable to find school with {schoolId} id");
                    return NotFound();
                }
                var result = await _degreesAwardedRepository.GetSchoolDegreesAwardedAsync(schoolId);
                if (result == null)
                {
                    _logger.LogWarning($"Unable to get degrees awarded for id: {schoolId}");
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"while getting id:{schoolId} degrees awarded.", ex.StackTrace);
                return StatusCode(500, ErrorMessages.InternalServerError);              
            }
        }
    }
}