using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniversityData.BindingModels.CostToAttend;
using UniversityData.Constants;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class CostToAttendController : Controller
    {
        private readonly ICostToAttendRepository _costToAttendRepository;
        private readonly ILogger<CostToAttendController> _logger;
        public CostToAttendController(
            ICostToAttendRepository costToAttendRepository,
            ILogger<CostToAttendController> logger)
        {
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

        // GET: api/costToAttend/private
        [HttpGet("private")]
        public async Task<IActionResult> GetCostToAttendPrivateSchoolByIncome(int familyIncome)
        {
            try
            {
                var result = await _costToAttendRepository.GetSchoolCostOfPrivateSchoolByIncome(familyIncome);
                if (result == null)
                {
                    _logger.LogWarning($"Unable to get cost to attend a private school for this income.");
                    return NotFound();
                }
                var privateSchoolResults = Mapper.Map<IEnumerable<CostToAttendPrivate>>(result);
                return Ok(privateSchoolResults);
            } 
            catch (Exception ex) 
            {
                _logger.LogCritical($"An error occured while getting cost to attend a private school with income: {familyIncome}", ex.StackTrace);
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }

        // GET: api/costToAttend/public
        [HttpGet("public")]
        public async Task<IActionResult> GetCostToAttendPublicSchoolByIncome(int familyIncome)
        {
            try
            {
                var result = await _costToAttendRepository.GetSchoolCostOfPublicSchoolByIncome(familyIncome);
                if (result == null)
                {
                    _logger.LogWarning($"Unable to get cost to attend a public school for income: {familyIncome}.");
                    return NotFound();
                }
                var publicSchoolResults = Mapper.Map<IEnumerable<CostToAttendPublic>>(result);
                return Ok(publicSchoolResults);
            }
            catch (Exception ex) 
            {
                _logger.LogCritical($"An error occured while getting cost to attend a public school with income: {familyIncome}", ex.StackTrace);
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }
    }
}