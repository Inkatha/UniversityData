using Microsoft.AspNetCore.Mvc;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class FinancialAidProvidedController : Controller
    {
        private readonly IFinancialAidProvidedRepository _repository;
        public FinancialAidProvidedController(IFinancialAidProvidedRepository repository)
        {
            _repository = repository;
        }

        // GET: api/financialAidprovided
        [HttpGet]
        public IActionResult GetAllFinancialAidProvided()
        {
            var financialAidProvidedResults = _repository.GetAllFinancialAidProvided();
            return Ok(financialAidProvidedResults);
        }

        // GET: api/financialAidprovided/{schoolId}
        [HttpGet("{schoolId}")]
        public IActionResult GetSchoolFinancialAidProvided(int schoolId)
        {
            var financialAidProvidedResult = _repository.GetSchoolFinancialAidProvided(schoolId);
            return Ok(financialAidProvidedResult);
        }
    }
}