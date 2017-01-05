using Microsoft.AspNetCore.Mvc;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class DegreesAwardedController : Controller
    {
        private readonly IDegreesAwardedRepository _repository;
        public DegreesAwardedController(IDegreesAwardedRepository repository)
        {
            _repository = repository;
        }

        // GET: api/degreesawarded
        [HttpGet]
        public IActionResult GetAllDegreesAwarded()
        {
            var degreesAwardedResult =  _repository.GetAllDegreesAwarded();
            return Ok(degreesAwardedResult);
        }

        // GET: api/degreesawarded/{schoolId}
        [HttpGet("{schoolId}")]
        public IActionResult GetSchoolDegreesAwarded(int schoolId)
        {
            var degreesAwardedResult = _repository.GetSchoolDegreesAwarded(schoolId);
            return Ok(degreesAwardedResult);
        }
    }
}