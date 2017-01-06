using Microsoft.AspNetCore.Mvc;
using System;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class BasicInfoController : Controller
    {
        public IBasicInfoRepository _repository;

        public BasicInfoController(IBasicInfoRepository repository)
        {
            _repository = repository;
        }

        // GET: api/basicinfo
        [HttpGet]
        public IActionResult GetAllInformation()
        {
            var basicInfoResults = _repository.GetAllBasicInformation();
            return Ok(basicInfoResults);
        }

        // GET: api/basicinfo/{unitId}
        [HttpGet("{unitId}")]
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
                return StatusCode(500, "A problem occured while handling your request.");
            }
        }
        
        // GET: api/basicinfo/{unitId}/name
        [HttpGet("{unitId}/name")]
        public IActionResult GetSchoolName(int unitId)
        {
            try 
            {
                if (!_repository.SchoolExists(unitId))
                {
                    return NotFound();
                }

                var schoolName = _repository.GetSchoolName(unitId);
                if (schoolName == null)
                {
                    return NotFound();
                }

                return Ok(schoolName);
            }
            catch (Exception ex)
            {
                //TODO Add logging
                Console.WriteLine("An error occured:", ex.StackTrace);
                return StatusCode(500, "A problem occured while handling your request.");
            }
        }
    }
}