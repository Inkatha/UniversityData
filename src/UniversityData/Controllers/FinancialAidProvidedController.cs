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
        public IActionResult GetAllFinancialAidProvided()
        {
            var financialAidProvidedResults = _financialAidProvidedRepository.GetAllFinancialAidProvided();
            return Ok(financialAidProvidedResults);
        }

        // GET: api/financialaidprovided/{schoolId}
        [HttpGet("{schoolId}")]
        public IActionResult GetSchoolFinancialAidProvided(int schoolId)
        {
            var financialAidProvidedResult = _financialAidProvidedRepository.GetSchoolFinancialAidProvided(schoolId);
            return Ok(financialAidProvidedResult);
        }
    }
}