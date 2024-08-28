using BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicStandardsForRoundsAndInspectionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportTakerEmployeeController : ControllerBase
    {
        private readonly IReportTakerEmployeeRepository _reportTakerEmployeeRepository;

        public ReportTakerEmployeeController(IReportTakerEmployeeRepository reportTakerEmployeeRepository)
        {
           _reportTakerEmployeeRepository = reportTakerEmployeeRepository;
        }
        [HttpGet("GetReportTakersNames")]
        public IActionResult GetReportTakersNames()
        {
            var reportTakersNames = _reportTakerEmployeeRepository.GetReportTakersNames();
            return Ok(reportTakersNames);
        }
        [HttpGet("GetReportTakerNameById/{id}")]
        public IActionResult GetReportTakerNameById(int id)
        {
            var reportTakersName = _reportTakerEmployeeRepository.GetReportTakerNameById(id);
            return Ok(reportTakersName);
        }
    }
}
