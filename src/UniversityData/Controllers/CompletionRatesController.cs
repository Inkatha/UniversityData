using Microsoft.AspNetCore.Mvc;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class CompletionRatesController : Controller
    {
        private readonly ICompletionRatesRepository _repository;
        public CompletionRatesController(ICompletionRatesRepository repository)
        {
            _repository = repository;
        }

        // GET: api/completionrates
        [HttpGet]
        public IActionResult GetAllCompletionRates()
        {
            var completionRatesResults = _repository.GetAllCompletionRates();
            return Ok(completionRatesResults);            
        }

        // GET: api/completionsrates/{schoolid}
        [HttpGet("{schoolId}")]
        public IActionResult GetSchoolCompletionRates(int schoolId)
        {
            var completionRateResult = _repository.GetSchoolCompletionRates(schoolId);
            return Ok(completionRateResult);
        }
    }
}