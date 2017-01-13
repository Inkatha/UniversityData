using Microsoft.AspNetCore.Mvc;
using System;
using UniversityData.Services.Interfaces;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAllInformationAsync()
        {
            var result = await _basicInfoRepository.GetAllBasicInformationAsync();
            return Ok(result);
        }

        // GET: api/basicinfo/{unitId}
        [HttpGet("{unitId}")]
        public async Task<IActionResult> GetSchoolInformation(int unitId)
        {
            try 
            {
                if (await _basicInfoRepository.SchoolExistsAsync(unitId) == false)
                {
                    return NotFound();
                }

                var result = await _basicInfoRepository.GetSchoolBasicInformationAsync(unitId);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
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
        public async Task<IActionResult> GetSchoolName(int unitId)
        {
            try 
            {
                if (await _basicInfoRepository.SchoolExistsAsync(unitId) == false)
                {
                    return NotFound();
                }

                var result = await _basicInfoRepository.GetSchoolNameAsync(unitId);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
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
        public async Task<IActionResult> GetSchoolUrl(int unitId)
        {
            try 
            {
                if (await _basicInfoRepository.SchoolExistsAsync(unitId) == false)
                {
                    return NotFound();
                }

                var result = await _basicInfoRepository.GetSchoolUrlAsync(unitId);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occured:", ex.StackTrace);
                return StatusCode(500, "An error occured while handling your request");
            }
        }
    }
}