using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UniversityData.Service;
using System;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class BasicInfoController : Controller
    {
        private readonly UniversityContext _context;
        public IBasicInfoRepository _repository;

        public BasicInfoController(UniversityContext context, IBasicInfoRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        // GET: api/BasicInfo
        [HttpGet]
        public IActionResult GetAllInformation()
        {
            var basicInfoResults = _repository.GetAllBasicInformation();
            return Ok(basicInfoResults);
        }

        // GET: api/BasicInfo/1
        [HttpGet("{id}")]
        public IActionResult GetSchoolInformation(int unitId)
        {
            try 
            {
                if (!_repository.SchoolExists(unitId))
                {
                    return NotFound();
                }

                var basicInfoResults = _repository.GetSchoolBasicInformation(unitId);
                if (basicInfoResults == null)
                {
                    return NotFound();
                }

                return Ok(basicInfoResults);
            }
            catch (Exception ex)
            {
                //TODO Add logging
                Console.WriteLine("An Error Occured:" + ex.StackTrace);
                return StatusCode(500, "A problem occured while handling your request");
            }
        }
    }
}