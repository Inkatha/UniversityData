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
        public IActionResult GetAllDegreesAwarded()
        {
            var degreesAwardedResult =  _degreesAwardedRepository.GetAllDegreesAwarded();
            return Ok(degreesAwardedResult);
        }

        // GET: api/degreesawarded/{schoolId}
        [HttpGet("{schoolId}")]
        public IActionResult GetSchoolDegreesAwarded(int schoolId)
        {
            var degreesAwardedResult = _degreesAwardedRepository.GetSchoolDegreesAwarded(schoolId);
            return Ok(degreesAwardedResult);
        }
    }
}