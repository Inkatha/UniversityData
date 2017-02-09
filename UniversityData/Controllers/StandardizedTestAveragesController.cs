using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniversityData.Constants;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class StandardizedTestAveragesController : Controller
    {
        private readonly IStandardizedTestAveragesRepository _standardizedTestAveragesRepository;
        private readonly IBasicInfoRepository _basicInfoRepository;
        private readonly ILogger<StandardizedTestAveragesController> _logger;
        public StandardizedTestAveragesController(
            IStandardizedTestAveragesRepository standardizedTestAveragesRepository,
            IBasicInfoRepository basicInfoRepository,
            ILogger<StandardizedTestAveragesController> logger)
        {
            _standardizedTestAveragesRepository = standardizedTestAveragesRepository;
            _basicInfoRepository = basicInfoRepository;
            _logger = logger;
        }

        // GET: api/standardizedtestaverages
        [HttpGet]
        public async Task<IActionResult> GetAllStandardizedTestAveragesAsync()
        {
            try 
            {
                var results = await _standardizedTestAveragesRepository.GetAllStandardizedTestAveragesAsync();
                if (results == null)
                {
                    _logger.LogWarning("Unable to get all standardized test averages");
                    return NotFound();
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("An error occured while getting all standardized test averages", ex.StackTrace);
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }

        // GET: api/standardizedtestaverages/{schoolId}
        [HttpGet("{schoolId}")]
        public async Task<IActionResult> GetSchoolStandardizedTestAveragesAsync(int schoolId)
        {
            try 
            {
                var result = await _standardizedTestAveragesRepository.GetSchoolStandardizedTestAveragesAsync(schoolId);
                if (result == null)
                {
                    _logger.LogWarning($"Unable to get id:{schoolId} standardized test averages.");
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"An error occured while getting id:{schoolId} standardized test averages.", ex.StackTrace);
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }
    }
}