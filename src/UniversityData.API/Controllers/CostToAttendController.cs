using Microsoft.AspNetCore.Mvc;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class CostToAttendController : Controller
    {
        private readonly ICostToAttendRepository _repository;
        public CostToAttendController(ICostToAttendRepository repository)
        {
            _repository = repository;
        }

        // GET: api/costToAttend
        [HttpGet]
        public IActionResult GetAllCostToAttend()
        {
            var costToAttendResult = _repository.GetAllCostToAttend();
            return Ok(costToAttendResult);
        }

        // GET: api/costToAttend/{schoolId}
        [HttpGet("{schoolId}")]
        public IActionResult GetSchoolCostToAttend(int schoolId)
        {
            var costToAttendResult = _repository.GetSchoolCostToAttend(schoolId);
            return Ok(costToAttendResult);
        }
    }
}