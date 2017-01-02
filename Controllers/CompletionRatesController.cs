using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UniversityData.Service;

namespace UniversityData.Controllers 
{
    [Route("api/[controller]")]
    public class CompletionRatesController : Controller
    {
        private readonly UniversityContext _context;
        public CompletionRatesController(UniversityContext context)
        {
            _context = context;
        }

        // GET: api/completionrates
        [HttpGet]
        public IActionResult GetAllCompletionRates()
        {
            var completionRatesResults = _context.completionrates.ToList();
            return Ok(completionRatesResults);            
        }

        // GET: api/completionsrates/{schoolid}
        public IActionResult GetSchoolCompletionRates(int schoolId)
        {
            Console.WriteLine(schoolId);
            var completionRateResult = _context.completionrates.FirstOrDefault(c => c.schoolid == schoolId);
            Console.WriteLine(completionRateResult.schoolid);
            return Ok(completionRateResult);
        }
    }
}