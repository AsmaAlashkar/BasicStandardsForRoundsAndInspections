using BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces;
using BasicStandardsForRoundsAndInspectionsAPI.Models;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.MainstandardDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicStandardsForRoundsAndInspectionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainStandardController : ControllerBase
    {
        private readonly IMainStandardRepository _mainStandardRepository;

        public MainStandardController(IMainStandardRepository mainStandardRepository)
        {
           _mainStandardRepository = mainStandardRepository;
        }
        [HttpGet("GetMainStandards")]
        
        public IActionResult GetMainStandards()
        {
            var MainStandards = _mainStandardRepository.GetMainStandards();
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(MainStandards);
        }
        
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var mainStandard =  _mainStandardRepository.GetById(id);
            return Ok(mainStandard);
        }

        [HttpPut]
        [Route("EditById/{id}")]
        public IActionResult EditById(int id, EditMainStandardDTO editedMainStandardDTO)
        {
            var editedMainStandard = _mainStandardRepository.EditById(id,editedMainStandardDTO);
            return Ok(editedMainStandard);
        }
        [HttpPost("CreateMainStandard")]

        public IActionResult CreateMainStandard(CreateMainStandardDTO createMainStandardDTO)
        {
            var newMainStandard = _mainStandardRepository.CreateMainStandard(createMainStandardDTO);
            return Ok(newMainStandard);
        }
        [HttpDelete("DeleteMainStandard/{id}")]
        public IActionResult DeleteMainStandard(int id)
        {
            var deleted =  _mainStandardRepository.DeleteById(id);
            return Ok($"deleted {deleted}");
        }
    }
}
