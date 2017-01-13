using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class FinancialAidProvidedController : Controller
    {
        private readonly IFinancialAidProvidedRepository _financialAidProvidedRepository;
        public FinancialAidProvidedController(IFinancialAidProvidedRepository financialAidProvidedRepository)
        {
            _financialAidProvidedRepository = financialAidProvidedRepository;
        }

        // GET: api/financialaidprovided
        [HttpGet]
        public async Task<IActionResult> GetAllFinancialAidProvidedAsync()
        {
            var result = await _financialAidProvidedRepository.GetAllFinancialAidProvidedAsync();
            return Ok(result);
        }

        // GET: api/financialaidprovided/{schoolId}
        [HttpGet("{schoolId}")]
        public async Task<IActionResult> GetSchoolFinancialAidProvidedAsync(int schoolId)
        {
            var result = await _financialAidProvidedRepository.GetSchoolFinancialAidProvidedAsync(schoolId);
            return Ok(result);
        }
    }
}