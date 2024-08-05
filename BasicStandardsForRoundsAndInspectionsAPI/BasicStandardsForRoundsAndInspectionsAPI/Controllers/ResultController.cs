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
        [HttpGet("GetResultsOfReport/{hospitalId}/{reportDate}")]
        public IActionResult GetResultsOfReport(int hospitalId, DateTime reportDate)
        {
            var allResults = _resultRepository.GetResultsOfReport(hospitalId,reportDate);
      
            return Ok(allResults);
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
        [Route("EditResults")]
        public IActionResult EditResults(IEnumerable<EditResultDTO> editedResultDTOs)
        {
            var editedResults = _resultRepository.EditResults(editedResultDTOs);
            return Ok(editedResults);
        }

        [HttpDelete("DeleteResults/{hospitalId}/{reportDate}")]
        public IActionResult DeleteResults(int hospitalId, DateTime reportDate)
        {
            bool isDeleted = _resultRepository.DeleteResults(hospitalId,reportDate);
            if (isDeleted)
            {
                return Ok(true);
            }
            else
            {
                return NotFound(false);
            }
        }
        //[HttpGet("GetResultsByHospitalId/{hospitalId}")]
        //public IEnumerable<IndexReportDTO> GetResultsByHospitalId(int hospitalId)
        //{
        //    var resultsByHospitalId = _resultRepository.GetResultsByHospitalId(hospitalId);
        //    return resultsByHospitalId;
        //}

        //[HttpGet("GetResultsByReportTakerId/{employeeId}")]
        //public IEnumerable<IndexReportDTO> GetResultsByReportTakerId(int employeeId)
        //{
        //    var resultsByReportTakerId = _resultRepository.GetResultsByReportTakerId(employeeId);
        //    return resultsByReportTakerId;
        //}
        //[HttpGet("GetResultsByDate/{date}")]
        //public IEnumerable<IndexReportDTO> GetResultsByDate(DateTime date)
        //{
        //    var resultsByDate = _resultRepository.GetResultsByDate(date);
        //    return resultsByDate;
        //}

    }
}
