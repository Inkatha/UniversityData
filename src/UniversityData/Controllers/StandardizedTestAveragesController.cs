using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAllStandardizedTestAveragesAsync()
        {
            var result = await _standardizedTestAveragesRepository.GetAllStandardizedTestAveragesAsync();
            return Ok(result);
        }

        // GET: api/standardizedtestaverages/{schoolId}
        [HttpGet("{schoolId}")]
        public async Task<IActionResult> GetSchoolStandardizedTestAveragesAsync(int schoolId)
        {
            var result = await _standardizedTestAveragesRepository.GetSchoolStandardizedTestAveragesAsync(schoolId);
            return Ok(result);
        }
    }
}