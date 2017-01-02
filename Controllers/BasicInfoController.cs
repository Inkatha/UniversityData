using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UniversityData.Service;


namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class BasicInfoController : Controller
    {
        private readonly UniversityContext _context;
        public BasicInfoController(UniversityContext context)
        {
            _context = context;
        }

        // GET: api/BasicInfo
        [HttpGet]
        public IActionResult GetAllInformation()
        {
            var basicInfoResults = _context.basicinfo.ToList();
            return Ok(basicInfoResults);
        }

        // GET: api/BasicInfo/1
        [HttpGet("{id}")]
        public IActionResult GetSchoolInformation(int? unitId)
        {
            if (unitId == null)
            {
                return BadRequest();
            }
            
            var basicInfoResults = _context.basicinfo.FirstOrDefault(b => b.unitid == unitId);
            return Ok(basicInfoResults);
        }
    }
}