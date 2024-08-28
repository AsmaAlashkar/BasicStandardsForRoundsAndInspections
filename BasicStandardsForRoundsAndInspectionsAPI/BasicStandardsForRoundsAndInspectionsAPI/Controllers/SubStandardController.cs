using BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.SubStandardDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BasicStandardsForRoundsAndInspectionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubStandardController : ControllerBase
    {
        private readonly ISubStandardRepository _subStandardRepository;

        public SubStandardController(ISubStandardRepository subStandardRepository)
        {
            _subStandardRepository = subStandardRepository;
        }
        [HttpGet("GetAllSubStandards")]
        public IActionResult GetAllSubStandards()
        {
           var allSubStandards = _subStandardRepository.GetAllSubStandards();
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);
            return Ok(allSubStandards);
        }
        [HttpGet("GetSubStandardsByMainStandardId/{mainStandardId}")]
        public IEnumerable<IndexSubStandardDTO> GetSubStandardsByMainStandardId(int mainStandardId)
        {
            var allSubStandardsByMainStandardId = _subStandardRepository.GetSubStandardsByMainStandardId(mainStandardId);
            return allSubStandardsByMainStandardId;
        }
        [HttpGet("GetSubStandardById")]
        public IActionResult GetSubStandardById(int id)
        {
            var subStandard = _subStandardRepository.GetSubStandardById(id);
            return Ok(subStandard);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("CreateSubStandard")]
        public IActionResult CreateSubStandard(CreateSubStandardDTO createSubStandardDTO)
        {
            var newSubStandard = _subStandardRepository.CreateSubStandard(createSubStandardDTO);
            return Ok(newSubStandard);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("EditSubStandardById/{id}")]
        public IActionResult EditSubStandardById(int id, EditSubStandardDTO editSubStandardDTO)
        {
            var editedSubStandard =_subStandardRepository.EditSubStandardById(id, editSubStandardDTO);
            return Ok(editedSubStandard);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteSubStandardById/{id}")]
        public IActionResult DeleteSubStandardById(int id)
        {
            bool isDeleted = _subStandardRepository.DeleteSubStandardById(id);
            if (isDeleted)
            {
                return Ok(true);
            }
            else
            {
                return NotFound(false);
            }
        }
    }
}
