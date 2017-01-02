using Microsoft.AspNetCore.Mvc;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class InstitutionTypeController : Controller
    {
        private readonly IInstitutionTypeRepository _repository;
        public InstitutionTypeController(IInstitutionTypeRepository repository)
        {
            _repository = repository;
        }

        // GET: api/institutiontype
        [HttpGet]
        public IActionResult GetAllInstitutionType()
        {
            var institutionTypeResults = _repository.GetAllInstitutionType();
            return Ok(institutionTypeResults);
        }

        // GET: api/institutiontype/{schoolid}
        [HttpGet("{schoolid}")]
        public IActionResult GetSchoolInstitutionType(int schoolId)
        {
            var institutionTypeResult = _repository.GetSchoolInstitutionType(schoolId);
            return Ok(institutionTypeResult);
        }
    }
}