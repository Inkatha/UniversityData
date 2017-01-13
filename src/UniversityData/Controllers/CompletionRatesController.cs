using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAllCompletionRatesAsync()
        {
            var results = await _completionRatesRepository.GetAllCompletionRatesAsync();
            return Ok(results);
        }

        // GET: api/completionsrates/{schoolid}
        [HttpGet("{schoolId}")]
        public async Task<IActionResult> GetSchoolCompletionRatesAsync(int schoolId)
        {
            var result = await _completionRatesRepository.GetSchoolCompletionRatesAsync(schoolId);
            return Ok(result);
        }
    }
}