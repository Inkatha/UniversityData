using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UniversityData.Services.Interfaces;
using System;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class CompletionRatesController : Controller
    {
        private readonly ICompletionRatesRepository _completionRatesRepository;
        private readonly IBasicInfoRepository _basicInfoRepository;
        public CompletionRatesController(
            ICompletionRatesRepository completionRatesRepository,
            IBasicInfoRepository basicInfoRepository)
        {
            _completionRatesRepository = completionRatesRepository;
            _basicInfoRepository = basicInfoRepository;
        }

        // GET: api/completionrates
        [HttpGet]
        public async Task<IActionResult> GetAllCompletionRatesAsync()
        {
            try 
            {
                var results = await _completionRatesRepository.GetAllCompletionRatesAsync();
                return Ok(results);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured while handling your request:", ex);
                return StatusCode(500, "An error occured");    
            }
        }

        // GET: api/completionsrates/{schoolid}
        [HttpGet("{schoolId}")]
        public async Task<IActionResult> GetSchoolCompletionRatesAsync(int schoolId)
        {
            try
            {
                if (await _basicInfoRepository.SchoolExistsAsync(schoolId) == false)
                {
                    return NotFound();
                }
                var result = await _completionRatesRepository.GetSchoolCompletionRatesAsync(schoolId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured:", ex);
                return StatusCode(500, "An error occured.");
            }
        }
    }
}