using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniversityData.Constants;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class StudentLoanDebtsController : Controller
    {
        private readonly IStudentLoanDebtsRepository _studentLoanDebtsRepository;
        private readonly IBasicInfoRepository _basicInfoRepository;
        private readonly ILogger<StudentLoanDebtsController> _logger;
        public StudentLoanDebtsController(
            IStudentLoanDebtsRepository studentLoanDebtsRepository,
            IBasicInfoRepository basicInfoRepository,
            ILogger<StudentLoanDebtsController> logger)
        {
            _studentLoanDebtsRepository = studentLoanDebtsRepository;
            _basicInfoRepository = basicInfoRepository;
            _logger = logger;
        }

        // GET: api/studentloandebts
        [HttpGet]
        public async Task<IActionResult> GetAllStudentLoanDebtsAsync()
        {
            try 
            {
                var results = await _studentLoanDebtsRepository.GetAllStudentLoanDebtsAsync();
                if (results == null)
                {
                    _logger.LogWarning("Unable to get all student loan debts.");
                    return NotFound();
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("An error occured while getting all student loan debts.", ex.StackTrace);                
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }

        // GET: api/studentloandebts/{schoolId}
        [HttpGet("{schoolId}")]
        public async Task<IActionResult> GetSchoolStudentLoanDebtsAsync(int schoolId)
        {
            try 
            {
                if (await _basicInfoRepository.SchoolExistsAsync(schoolId) == false) 
                {
                    _logger.LogWarning($"Unable to find school with {schoolId} id");
                    return NotFound();
                }
                
                var result = await _studentLoanDebtsRepository.GetSchoolStudentLoanDebtsAsync(schoolId);
                if (result == null)
                {
                    _logger.LogWarning($"Unable to get id:{schoolId} student loan debts.");
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"An error occured while getting student loan debts for id:{schoolId}.", ex.StackTrace);
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }
    }
}