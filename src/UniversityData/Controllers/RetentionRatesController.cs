using Microsoft.AspNetCore.Mvc;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class RetentionRatesController : Controller
    {
        private readonly IRetentionRatesRepository _retentionRatesRepository;
        public RetentionRatesController(IRetentionRatesRepository retentionRatesRepository)
        {
            _retentionRatesRepository = retentionRatesRepository;
        }

        // GET: api/retentionrates
        [HttpGet]
        public IActionResult GetAllRetentionRates()
        {
            var retentionRatesResults = _retentionRatesRepository.GetAllRetentionRates();
            return Ok(retentionRatesResults);
        }

        // GET: api/retentionrates/{schoolId}
        [HttpGet("{schoolId}")]
        public IActionResult GetSchoolRetentionRates(int schoolId)
        {
            var retentionRatesResult = _retentionRatesRepository.GetSchoolRetentionRates(schoolId);
            return Ok(retentionRatesResult);
        }
    }
}