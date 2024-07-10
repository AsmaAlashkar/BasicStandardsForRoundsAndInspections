using BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.ResultDTO;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.SubStandardDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicStandardsForRoundsAndInspectionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IResultRepository _resultRepository;

        public ResultController(IResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }
        [HttpGet("GetResults")]
        public IActionResult GetResults()
        {
            var allResults = _resultRepository.GetResults();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(allResults);
        }
        [HttpGet("GetResultBySubStandardId/{subStandardId}")]
        public IEnumerable<IndexResultDTO> GetResultBySubStandardId(int subStandardId)
        {
            var allResultBySubStandardId = _resultRepository.GetResultBySubStandardId(subStandardId);
            return allResultBySubStandardId;
        }
        [HttpGet("GetResultById/{id}")]
        public IActionResult GetResultById(int id)
        {
            var result = _resultRepository.GetResultById(id);
            return Ok(result);
        }
        [HttpPost]
        [Route("CreateResult")]
        public IActionResult CreateResult(CreateResultDTO createResultDTO)
        {
            var result = _resultRepository.CreateOrUpdateResult(createResultDTO);
            return Ok(result);
        }
        //[HttpPut]
        //[Route("EditResultById/{id}")]
        //public IActionResult EditResultById(int id, EditResultDTO editedResultDTO)
        //{
        //    var editedResult = _resultRepository.EditResultById(id, editedResultDTO);
        //    return Ok(editedResult);
        //}
        [HttpDelete("DeleteResultById/{id}")]
        public IActionResult DeleteResultById(int id)
        {
            bool isDeleted = _resultRepository.DeleteResultById(id);
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
