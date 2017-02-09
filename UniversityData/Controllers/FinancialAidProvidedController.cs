using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniversityData.Constants;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class FinancialAidProvidedController : Controller
    {
        private readonly IFinancialAidProvidedRepository _financialAidProvidedRepository;
        private readonly IBasicInfoRepository _basicInfoRepository;
        private readonly ILogger<FinancialAidProvidedController> _logger;
        public FinancialAidProvidedController(
            IFinancialAidProvidedRepository financialAidProvidedRepository,
            IBasicInfoRepository basicInfoRepository,
            ILogger<FinancialAidProvidedController> logger)
        {
            _financialAidProvidedRepository = financialAidProvidedRepository;
            _basicInfoRepository = basicInfoRepository;
            _logger = logger;
        }

        // GET: api/financialaidprovided
        [HttpGet]
        public async Task<IActionResult> GetAllFinancialAidProvidedAsync()
        {
            try 
            {
                var results = await _financialAidProvidedRepository.GetAllFinancialAidProvidedAsync();
                if (results == null)
                {
                    _logger.LogWarning("Unable to get all financial aid provided");
                    return NotFound();
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Unable to get all financial aid provided", ex.StackTrace);
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }

        // GET: api/financialaidprovided/{schoolId}
        [HttpGet("{schoolId}")]
        public async Task<IActionResult> GetSchoolFinancialAidProvidedAsync(int schoolId)
        {
            try 
            {
                if (await _basicInfoRepository.SchoolExistsAsync(schoolId) == false)
                {
                    _logger.LogWarning($"a school with id:{schoolId} does not exist.");
                    return NotFound();
                }
                var result = await _financialAidProvidedRepository.GetSchoolFinancialAidProvidedAsync(schoolId);
                if (result == null)
                {
                    _logger.LogWarning($"Unable to get id:{schoolId} financial aid provided.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Unable to get id:{schoolId} financial aid provided", ex.StackTrace);
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }
    }
}