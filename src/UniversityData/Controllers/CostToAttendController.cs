using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class CostToAttendController : Controller
    {
        private readonly ICostToAttendRepository _costToAttendRepository;
        private readonly IBasicInfoRepository _basicInfoRepository;
        private readonly ILogger _logger;
        public CostToAttendController(
            ICostToAttendRepository costToAttendRepository,
            IBasicInfoRepository basicInfoRepository,
            ILogger logger)
        {
            _basicInfoRepository = basicInfoRepository;
            _costToAttendRepository = costToAttendRepository;
            _logger = logger;
        }

        // GET: api/costtoattend
        [HttpGet]
        public async Task<IActionResult> GetAllCostToAttendAsync()
        {
            try 
            {
                var results = await _costToAttendRepository.GetAllCostToAttendAsync();
                return Ok(results);
            }
            catch(Exception ex)
            {
                _logger.LogCritical("An error occured", ex);
                return StatusCode(500, "An error occured");
            }
        }

        // GET: api/costToAttend/{schoolId}
        [HttpGet("{schoolId}")]
        public async Task<IActionResult> GetSchoolCostToAttend(int schoolId)
        {
            try
            {
                if (await _basicInfoRepository.SchoolExistsAsync(schoolId) == false)
                {
                    _logger.LogWarning($"Unable to find a school with {schoolId}");
                    return NotFound();
                }
                var result = await _costToAttendRepository.GetSchoolCostToAttendAsync(schoolId);
                if (result == null)
                {
                    _logger.LogWarning($"Unable to get cost to attend for id: {schoolId}");
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("an error occured: ", ex);
                return StatusCode(500, "An error occured");
            }
        }
    }
}