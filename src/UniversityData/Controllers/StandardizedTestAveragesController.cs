using Microsoft.AspNetCore.Mvc;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class StandardizedTestAveragesController : Controller
    {
        private readonly IStandardizedTestAveragesRepository _standardizedTestAveragesRepository;
        public StandardizedTestAveragesController(IStandardizedTestAveragesRepository standardizedTestAveragesRepository)
        {
            _standardizedTestAveragesRepository = standardizedTestAveragesRepository;
        }

        // GET: api/standardizedtestaverages
        [HttpGet]
        public IActionResult GetAllStandardizedTestAverages()
        {
            // TODO: Figure out why this causes an error
            var standardizedTestAveragesResults = _standardizedTestAveragesRepository.GetAllStandardizedTestAverages();
            return Ok(standardizedTestAveragesResults);
        }

        // GET: api/standardizedtestaverages/{schoolId}
        [HttpGet("{schoolId}")]
        public IActionResult GetSchoolStandardizedTestAverages(int schoolId)
        {
            var standardizedTestAveragesResult = _standardizedTestAveragesRepository.GetSchoolStandardizedTestAverages(schoolId);
            return Ok(standardizedTestAveragesResult);
        }
    }
}