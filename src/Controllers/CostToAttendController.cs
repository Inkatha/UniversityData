using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniversityData.Constants;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class CostToAttendController : Controller
    {
        private readonly ICostToAttendRepository _costToAttendRepository;
        private readonly IBasicInfoRepository _basicInfoRepository;
        private readonly ILogger<CostToAttendController> _logger;
        public CostToAttendController(
            ICostToAttendRepository costToAttendRepository,
            IBasicInfoRepository basicInfoRepository,
            ILogger<CostToAttendController> logger)
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
                if (results == null)
                {
                    _logger.LogWarning($"Unable to get all costs to attend.");
                    return NotFound();
                }
                return Ok(results);
            }
            catch(Exception ex)
            {
                _logger.LogCritical("An error occured while getting all cost to attend data.", ex.StackTrace);
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }

        // GET: api/costToAttend/{schoolId}
        [HttpGet("{schoolId}")]
        public async Task<IActionResult> GetSchoolCostToAttend(int schoolId)
        {
            try
            {
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
                _logger.LogCritical($"an error occured while getting id:{schoolId} cost to attend data.", ex.StackTrace);
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }

        // GET: api/costToAttend/{schoolid}/greaterThan
        [HttpGet("{schoolId}/greaterThan/{cost}")]
        public async Task<IActionResult> GetCostToAttendGreaterThan(int schoolId, int cost)
        {
            try
            {
                return Ok();
            } 
            catch (Exception ex) 
            {
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }

        // GET: api/costToAttend/{schoolid}/lessThan
        [HttpGet("{schoolId}/lessThan/{cost}")]
        public async Task<IActionResult> GetCostToAttendLessThan(int schoolId, int cost)
        {
           try
            {
                return Ok();
            } 
            catch (Exception ex) 
            {
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }

        // GET: api/costToAttend/{schoolid}/between
        [HttpGet("{schoolId}/between/{cost}")]
        public async Task<IActionResult> GetCostToAttendBetween(int schoolId, int cost)
        {
           try
            {
                return Ok();
            } 
            catch (Exception ex) 
            {
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }
    }
}