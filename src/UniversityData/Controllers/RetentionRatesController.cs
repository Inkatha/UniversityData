using Microsoft.AspNetCore.Mvc;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class RetentionRatesController : Controller
    {
        private readonly IRetentionRatesRepository _repository;
        public RetentionRatesController(IRetentionRatesRepository repository)
        {
            _repository = repository;
        }

        // GET: api/retentionrates
        [HttpGet]
        public IActionResult GetAllRetentionRates()
        {
            var retentionRatesResults = _repository.GetAllRetentionRates();
            return Ok(retentionRatesResults);
        }

        // GET: api/retentionrates/{schoolId}
        [HttpGet("{schoolId}")]
        public IActionResult GetSchoolRetentionRates(int schoolId)
        {
            var retentionRatesResult = _repository.GetSchoolRetentionRates(schoolId);
            return Ok(retentionRatesResult);
        }
    }
}