using Microsoft.AspNetCore.Mvc;
using System;
using UniversityData.Services.Interfaces;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    public class BasicInfoController : Controller
    {
        public IBasicInfoRepository _basicInfoRepository;

        public BasicInfoController(IBasicInfoRepository basicInfoRepository)
        {
            _basicInfoRepository = basicInfoRepository;
        }

        // GET: api/basicinfo
        [HttpGet]
        public IActionResult GetAllInformation()
        {
            var basicInfoResults = _basicInfoRepository.GetAllBasicInformation();
            return Ok(basicInfoResults);
        }

        // GET: api/basicinfo/{unitId}
        [HttpGet("{unitId}")]
        public IActionResult GetSchoolInformation(int unitId)
        {
            try 
            {
                if (!_basicInfoRepository.SchoolExists(unitId))
                {
                    return NotFound();
                }

                var basicInfoResults = _basicInfoRepository.GetSchoolBasicInformation(unitId);
                if (basicInfoResults == null)
                {
                    return NotFound();
                }

                return Ok(basicInfoResults);
            }
            catch (Exception ex)
            {
                //TODO Add logging
                Console.WriteLine("An error occured:" + ex.StackTrace);
                return StatusCode(500, "A problem occured while handling your request.");
            }
        }
        
        // GET: api/basicinfo/{unitId}/name
        [HttpGet("{unitId}/name")]
        public IActionResult GetSchoolName(int unitId)
        {
            try 
            {
                if (!_basicInfoRepository.SchoolExists(unitId))
                {
                    return NotFound();
                }

                var schoolName = _basicInfoRepository.GetSchoolName(unitId);
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

        // GET: api/basicinfo/{unitId}/url
        [HttpGet("{unitId}/url")]
        public IActionResult GetSchoolUrl(int unitId)
        {
            try 
            {
                if (!_basicInfoRepository.SchoolExists(unitId))
                {
                    return NotFound();
                }

                var schoolUrl = _basicInfoRepository.GetSchoolUrl(unitId);
                if (schoolUrl == null)
                {
                    return NotFound();
                }

                return Ok(schoolUrl);
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occured:", ex.StackTrace);
                return StatusCode(500, "An error occured while handling your request");
            }
        }
    }
}