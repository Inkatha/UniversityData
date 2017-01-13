using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAllRetentionRatesAsync()
        {
            var results = await _retentionRatesRepository.GetAllRetentionRatesAsync();
            return Ok(results);
        }

        // GET: api/retentionrates/{schoolId}
        [HttpGet("{schoolId}")]
        public async Task<IActionResult> GetSchoolRetentionRates(int schoolId)
        {
            var result = await _retentionRatesRepository.GetSchoolRetentionRatesAsync(schoolId);
            return Ok(result);
        }
    }
}