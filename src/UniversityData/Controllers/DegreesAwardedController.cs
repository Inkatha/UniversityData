using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class DegreesAwardedController : Controller
    {
        private readonly IDegreesAwardedRepository _degreesAwardedRepository;
        public DegreesAwardedController(IDegreesAwardedRepository degreesAwardedRepository)
        {
            _degreesAwardedRepository = degreesAwardedRepository;
        }

        // GET: api/degreesawarded
        [HttpGet]
        public async Task<IActionResult> GetAllDegreesAwardedAsync()
        {
            try 
            {
                var result = await _degreesAwardedRepository.GetAllDegreesAwardedAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("an error occured: ", ex);
                return StatusCode(500, "An error occured");
            }
        }

        // GET: api/degreesawarded/{schoolId}
        [HttpGet("{schoolId}")]
        public async Task<IActionResult> GetSchoolDegreesAwardedAsync(int schoolId)
        {
            try 
            {
                var result = await _degreesAwardedRepository.GetSchoolDegreesAwardedAsync(schoolId);
                if (result == null)
                {
                    Console.WriteLine($"Unable to get degrees awarded for id: {schoolId}");
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("an error occured:  ", ex);  
                return StatusCode(500, "An error occured:");              
            }
        }
    }
}