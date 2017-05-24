using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniversityData.Constants;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class InstitutionTypeController : Controller
    {
        private readonly IInstitutionTypeRepository _institutionTypeRepository;
        private readonly ILogger<InstitutionTypeController> _logger;
        public InstitutionTypeController(
            IInstitutionTypeRepository institutionTypeRepository,
            ILogger<InstitutionTypeController> logger)
        {
            _institutionTypeRepository = institutionTypeRepository;
            _logger = logger;
        }

        // GET: api/institutiontype
        [HttpGet]
        public async Task<IActionResult> GetAllInstitutionTypeAsync()
        {
            try 
            {
                var results = await _institutionTypeRepository.GetAllInstitutionTypeAsync();
                if (results == null)
                {
                    _logger.LogWarning("Unable to get all institution types.");
                    return NotFound();
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("An error occured while getting all institution types.", ex.StackTrace);
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }

        // GET: api/institutiontype/{schoolid}
        [HttpGet("{schoolid}")]
        public async Task<IActionResult> GetSchoolInstitutionTypeAsync(int schoolId)
        {
            try 
            {
                var result = await _institutionTypeRepository.GetSchoolInstitutionTypeAsync(schoolId);
                if (result == null)
                {
                    _logger.LogWarning($"Unable to get id:{schoolId} institution type");
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning("An error occured while getting id:{schoolId} institution type", ex.StackTrace);
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }
    }
}