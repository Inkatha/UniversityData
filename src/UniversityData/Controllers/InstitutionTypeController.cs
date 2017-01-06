using Microsoft.AspNetCore.Mvc;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class InstitutionTypeController : Controller
    {
        private readonly IInstitutionTypeRepository _institutionTypeRepository;
        public InstitutionTypeController(IInstitutionTypeRepository institutionTypeRepository)
        {
            _institutionTypeRepository = institutionTypeRepository;
        }

        // GET: api/institutiontype
        [HttpGet]
        public IActionResult GetAllInstitutionType()
        {
            var institutionTypeResults = _institutionTypeRepository.GetAllInstitutionType();
            return Ok(institutionTypeResults);
        }

        // GET: api/institutiontype/{schoolid}
        [HttpGet("{schoolid}")]
        public IActionResult GetSchoolInstitutionType(int schoolId)
        {
            var institutionTypeResult = _institutionTypeRepository.GetSchoolInstitutionType(schoolId);
            return Ok(institutionTypeResult);
        }
    }
}