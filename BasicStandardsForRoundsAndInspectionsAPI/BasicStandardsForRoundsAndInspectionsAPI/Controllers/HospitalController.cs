using BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicStandardsForRoundsAndInspectionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalRepository _hospitalRepository;

        public HospitalController(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }
        [HttpGet("GetAllHospitalsNames")]
        public IActionResult GetAllHospitalsNames()
        {
            var hospitals = _hospitalRepository.GetAllHospitalsNames();
            return Ok(hospitals);
        }
    }
}
