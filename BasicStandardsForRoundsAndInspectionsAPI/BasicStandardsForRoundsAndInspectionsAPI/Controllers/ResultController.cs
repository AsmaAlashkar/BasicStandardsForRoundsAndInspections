using BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces;
using BasicStandardsForRoundsAndInspectionsAPI.Models.Models;
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
        [HttpGet("GetReports")]
        public IActionResult GetReports()
        {
            var allResults = _resultRepository.GetReports();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(allResults);
        }

        [HttpGet("GetResultsByHospitalId/{hospitalId}")]
        public IEnumerable<IndexReportDTO> GetResultsByHospitalId(int hospitalId)
        {
            var resultsByHospitalId = _resultRepository.GetResultsByHospitalId(hospitalId);
            return resultsByHospitalId;
        }

        [HttpGet("GetResultsByReportTakerId/{employeeId}")]
        public IEnumerable<IndexReportDTO> GetResultsByReportTakerId(int employeeId)
        {
            var resultsByReportTakerId = _resultRepository.GetResultsByReportTakerId(employeeId);
            return resultsByReportTakerId;
        }
        [HttpGet("GetResultsByDate/{date}")]
        public IEnumerable<IndexReportDTO> GetResultsByDate(DateTime date)
        {
            var resultsByDate = _resultRepository.GetResultsByDate(date);
            return resultsByDate;
        }

        [HttpPost]
        [Route("CreateResults")]
        public IActionResult CreateResults(IEnumerable<CreateResultDTO> createResultDTO)
        {
            var result = _resultRepository.CreateResults (createResultDTO);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(result);
        }

        [HttpPut]
        [Route("EditResult")]
        public IActionResult EditResult(EditResultDTO editedResultDTO)
        {
            var editedResult = _resultRepository.EditResult(editedResultDTO);
            return Ok(editedResult);
        }

        [HttpDelete("DeleteResult")]
        public IActionResult DeleteResult(DeleteResultDTO deletedResultDTO)
        {
            bool isDeleted = _resultRepository.DeleteResult(deletedResultDTO);
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
