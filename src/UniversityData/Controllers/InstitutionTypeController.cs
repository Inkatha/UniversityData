using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAllInstitutionTypeAsync()
        {
            var result = await _institutionTypeRepository.GetAllInstitutionTypeAsync();
            return Ok(result);
        }

        // GET: api/institutiontype/{schoolid}
        [HttpGet("{schoolid}")]
        public async Task<IActionResult> GetSchoolInstitutionTypeAsync(int schoolId)
        {
            var result = await _institutionTypeRepository.GetSchoolInstitutionTypeAsync(schoolId);
            return Ok(result);
        }
    }
}