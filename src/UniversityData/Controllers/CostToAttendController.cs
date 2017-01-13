using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class CostToAttendController : Controller
    {
        private readonly ICostToAttendRepository _costToAttendRepository;
        public CostToAttendController(ICostToAttendRepository costToAttendRepository)
        {
            _costToAttendRepository = costToAttendRepository;
        }

        // GET: api/costtoattend
        [HttpGet]
        public async Task<IActionResult> GetAllCostToAttendAsync()
        {
            var results = await _costToAttendRepository.GetAllCostToAttendAsync();
            return Ok(results);
        }

        // GET: api/costToAttend/{schoolId}
        [HttpGet("{schoolId}")]
        public async Task<IActionResult> GetSchoolCostToAttend(int schoolId)
        {
            var result = await _costToAttendRepository.GetSchoolCostToAttendAsync(schoolId);
            return Ok(result);
        }
    }
}