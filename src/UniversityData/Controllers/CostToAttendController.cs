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
        public IActionResult GetAllCostToAttend()
        {
            var costToAttendResult = _costToAttendRepository.GetAllCostToAttend();
            return Ok(costToAttendResult);
        }

        // GET: api/costToAttend/{schoolId}
        [HttpGet("{schoolId}")]
        public IActionResult GetSchoolCostToAttend(int schoolId)
        {
            var costToAttendResult = _costToAttendRepository.GetSchoolCostToAttend(schoolId);
            return Ok(costToAttendResult);
        }
    }
}