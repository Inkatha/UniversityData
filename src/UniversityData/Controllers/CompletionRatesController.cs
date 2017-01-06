using Microsoft.AspNetCore.Mvc;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class CompletionRatesController : Controller
    {
        private readonly ICompletionRatesRepository _completionRatesRepository;
        public CompletionRatesController(ICompletionRatesRepository completionRatesRepository)
        {
            _completionRatesRepository = completionRatesRepository;
        }

        // GET: api/completionrates
        [HttpGet]
        public IActionResult GetAllCompletionRates()
        {
            var completionRatesResults = _completionRatesRepository.GetAllCompletionRates();
            return Ok(completionRatesResults);            
        }

        // GET: api/completionsrates/{schoolid}
        [HttpGet("{schoolId}")]
        public IActionResult GetSchoolCompletionRates(int schoolId)
        {
            var completionRateResult = _completionRatesRepository.GetSchoolCompletionRates(schoolId);
            return Ok(completionRateResult);
        }
    }
}