using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class CostToAttendController : Controller
    {
        private readonly ICostToAttendRepository _costToAttendRepository;
        private readonly IBasicInfoRepository _basicInfoRepository;
        public CostToAttendController(
            ICostToAttendRepository costToAttendRepository,
            IBasicInfoRepository basicInfoRepository)
        {
            _basicInfoRepository = basicInfoRepository;
            _costToAttendRepository = costToAttendRepository;
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
                Console.WriteLine("An error occured", ex);
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
                    
                    return NotFound();
                }
                var result = await _costToAttendRepository.GetSchoolCostToAttendAsync(schoolId);
                if (result == null)
                {
                    Console.WriteLine($"Unable to get cost to attend for id: {schoolId}");
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("an error occured: ", ex);
                return StatusCode(500, "An error occured");
            }
        }
    }
}