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
            var result = await _degreesAwardedRepository.GetAllDegreesAwardedAsync();
            return Ok(result);
        }

        // GET: api/degreesawarded/{schoolId}
        [HttpGet("{schoolId}")]
        public async Task<IActionResult> GetSchoolDegreesAwardedAsync(int schoolId)
        {
            var result = await _degreesAwardedRepository.GetSchoolDegreesAwardedAsync(schoolId);
            return Ok(result);
        }
    }
}