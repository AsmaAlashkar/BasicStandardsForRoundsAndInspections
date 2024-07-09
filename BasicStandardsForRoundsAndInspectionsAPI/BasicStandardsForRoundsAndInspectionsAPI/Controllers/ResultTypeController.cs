using BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicStandardsForRoundsAndInspectionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultTypeController : ControllerBase
    {
        private readonly IResultTypeRepository _resultTypeRepository;

        public ResultTypeController(IResultTypeRepository resultTypeRepository)
        {
            _resultTypeRepository = resultTypeRepository;
        }
        [HttpGet("GetResultTypes")]
        public IActionResult GetResultTypes() 
        {
            var resultTypes = _resultTypeRepository.GetAllResultTypes();
            if (!ModelState.IsValid)
            {
                return BadRequest();    
            }
            return Ok(resultTypes);
        }
        [HttpGet]
        [Route("GetResultTypesById/{id}")]
        public IActionResult GetResultTypesById(int id)
        {
            var resultTypes = _resultTypeRepository.GetResultTypesById(id);
            return Ok(resultTypes);
        }
    }
}
