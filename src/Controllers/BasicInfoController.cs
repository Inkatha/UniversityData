using Microsoft.AspNetCore.Mvc;
using System;
using UniversityData.Services.Interfaces;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using UniversityData.Constants;

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
                var results = await _basicInfoRepository.GetAllBasicInformationAsync();
                if (results == null)
                {
                    _logger.LogWarning($"Unable to all basic information.");
                    return NotFound();
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("An exception occured while getting all basic information.", ex);
                return StatusCode(500, ErrorMessages.InternalServerError);
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
                    _logger.LogWarning($"Unable to get basic information for id: {unitId}.");
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"An error occured while getting {unitId} basic information." + ex.StackTrace);
                return StatusCode(500, ErrorMessages.InternalServerError);
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
                    _logger.LogWarning($"Unable to get basic information for id: {unitId}.");
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"an error occured while getting id:{unitId} school name.", ex.StackTrace);
                return StatusCode(500, ErrorMessages.InternalServerError);
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
                _logger.LogCritical($"an error occured while getting {unitId} school url.", ex.StackTrace);
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }

        [HttpGet("search/{searchTerm}")]
        public async Task<IActionResult> SchoolSearch(string searchTerm) {
            try 
            {
                var result = await _basicInfoRepository.SchoolSearchAsync(searchTerm);
                if (result == null) {
                    _logger.LogWarning($"Unable to get search for id: {searchTerm}.");
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex) {
                _logger.LogCritical($"an error occured while getting searching {searchTerm}", ex.StackTrace);
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }
    }
}