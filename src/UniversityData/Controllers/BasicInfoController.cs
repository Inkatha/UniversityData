using Microsoft.AspNetCore.Mvc;
using System;
using UniversityData.Services.Interfaces;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class BasicInfoController : Controller
    {
        private readonly IBasicInfoRepository _basicInfoRepository;
        private readonly ILogger<BasicInfoController> _logger;
        public BasicInfoController(IBasicInfoRepository basicInfoRepository, ILogger<BasicInfoController> logger)
        {
            _basicInfoRepository = basicInfoRepository;
            _logger = logger;
        }

        // GET: api/basicinfo
        [HttpGet]
        public async Task<IActionResult> GetAllInformationAsync()
        {
            try 
            {
                var result = await _basicInfoRepository.GetAllBasicInformationAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("An exception occured", ex);
                return StatusCode(500, "An error occured");
            }
        }

        // GET: api/basicinfo/{unitId}
        [HttpGet("{unitId}")]
        public async Task<IActionResult> GetSchoolInformation(int unitId)
        {
            try 
            {
                if (await _basicInfoRepository.SchoolExistsAsync(unitId) == false)
                {
                    _logger.LogWarning($"A school with the id: {unitId} does not exist.");
                    return NotFound();
                }

                var result = await _basicInfoRepository.GetSchoolBasicInformationAsync(unitId);
                if (result == null)
                {
                    _logger.LogWarning($"Unable to get basic information for id: {unitId}");
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("an error occured: " + ex.StackTrace);
                return StatusCode(500, "A problem occured while handling your request.");
            }
        }
        
        // GET: api/basicinfo/{unitId}/name
        [HttpGet("{unitId}/name")]
        public async Task<IActionResult> GetSchoolName(int unitId)
        {
            try 
            {
                if (await _basicInfoRepository.SchoolExistsAsync(unitId) == false)
                {
                    _logger.LogWarning($"A school with the id: {unitId} does not exist.");
                    return NotFound();
                }

                var result = await _basicInfoRepository.GetSchoolNameAsync(unitId);
                if (result == null)
                {
                    _logger.LogWarning($"Unable to get basic information for id: {unitId}");
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("an error occured: ", ex.StackTrace);
                return StatusCode(500, "A problem occured while handling your request.");
            }
        }

        // GET: api/basicinfo/{unitId}/url
        [HttpGet("{unitId}/url")]
        public async Task<IActionResult> GetSchoolUrl(int unitId)
        {
            try 
            {
                if (await _basicInfoRepository.SchoolExistsAsync(unitId) == false)
                {
                    _logger.LogWarning($"A school with the id: {unitId} does not exist.");
                    return NotFound();
                }

                var result = await _basicInfoRepository.GetSchoolUrlAsync(unitId);
                if (result == null)
                {
                    _logger.LogWarning($"Unable to get basic information for id: {unitId}.");
                    return NotFound();
                }

                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogCritical("an error occured: ", ex.StackTrace);
                return StatusCode(500, "An error occured while handling your request");
            }
        }
    }
}