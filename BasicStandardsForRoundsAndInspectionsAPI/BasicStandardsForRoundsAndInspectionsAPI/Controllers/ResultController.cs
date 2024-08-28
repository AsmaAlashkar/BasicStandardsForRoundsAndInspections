using BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.ResultDTO;
using Microsoft.AspNetCore.Authorization;

using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Mvc;



namespace BasicStandardsForRoundsAndInspectionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            var allResults = _resultRepository.GetResultsOfReport(hospitalId, reportDate);

            return Ok(allResults);
        }

        [HttpPost]
        [Route("CreateResults")]
        public IActionResult CreateResults(IEnumerable<CreateResultDTO> createResultDTO)
        {
            var result = _resultRepository.CreateResults(createResultDTO);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(result);
        }
        [HttpGet("GetResultsForEditReport/{hospitalId}/{reportDate}")]
        public IActionResult GetResultsForEditReport(int hospitalId, DateTime reportDate)
        {
            var resultsForEditReport = _resultRepository.GetResultsForEditReport(hospitalId, reportDate);
            return Ok(resultsForEditReport);
        }

        [HttpPut]
        [Route("EditResults/{hospitalId}/{reportDate}")]
        public IActionResult EditResults(IEnumerable<EditResultDTO> editedResultDTOs, int hospitalId, DateTime reportDate)
        {
            var editedResults = _resultRepository.EditResults(editedResultDTOs, hospitalId, reportDate);
            return Ok(editedResults);
        }

        [HttpDelete("DeleteResults/{hospitalId}/{reportDate}")]
        public IActionResult DeleteResults(int hospitalId, DateTime reportDate)
        {
            bool isDeleted = _resultRepository.DeleteResults(hospitalId, reportDate);
            if (isDeleted)
            {
                return Ok(true);
            }
            else
            {
                return NotFound(false);
            }
        }

        [HttpGet("DownloadReport/{hospitalId}/{reportDate}/{language}")]
        public IActionResult DownloadReport(int hospitalId, DateTime reportDate, string language)
        {
            var results = _resultRepository.GetResultsOfReport(hospitalId, reportDate);

            byte[] fileContents = GenerateReportAsPdf(results, language);

            var fileName = $"Report_{hospitalId}_{reportDate:yyyy-MM-dd}.pdf";

            return File(fileContents, "application/pdf", fileName);
        }
        private byte[] GenerateReportAsPdf(IEnumerable<IndexResultsOfReportDTO> results, string language)
        {
            using (var memoryStream = new MemoryStream())
            {
                PdfWriter writer = new PdfWriter(memoryStream);
                PdfDocument pdfDoc = new PdfDocument(writer);
                Document document = new Document(pdfDoc);

                string fontPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fonts", "adobearabic.ttf");
                PdfFont font = PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H);


                TextAlignment alignment = language == "ar" ? TextAlignment.RIGHT : TextAlignment.LEFT;


                Paragraph CreateParagraph(string text, string lang)
                {
                    return new Paragraph(text)
                        .SetFont(font)
                        .SetFontSize(20)
                        .SetTextAlignment(alignment);
                }

                document.Add(CreateParagraph(language == "ar" ? "التقرير" : "Report", language)
                    .SetFontSize(20)
                    .SetBold());

                foreach (var result in results)
                {
                    document.Add(CreateParagraph(
                        language == "ar" ? $"{result.HospitalNameAr}" : $"{result.HospitalName}", language));
                    document.Add(CreateParagraph(
                        language == "ar" ? $"{result.ReportDate:yyyy-MM-dd}" : $"{result.ReportDate:yyyy-MM-dd}", language));

                    foreach (var mainStandard in result.MainStandards)
                    {
                        document.Add(CreateParagraph(
                            language == "ar" ? $"{mainStandard.TitleAr}" : $"{mainStandard.Title}", language));

                        foreach (var subStandard in mainStandard.Substandards)
                        {
                            document.Add(CreateParagraph(
                                language == "ar" ? $"{subStandard.DescriptionAr}" : $"{subStandard.Description}", language));
                            document.Add(CreateParagraph(
                                language == "ar" ? $"{subStandard.ResultValue}" : $"{subStandard.ResultValue}", language));
                            document.Add(CreateParagraph(
                                language == "ar" ? $"{subStandard.Comment}" : $"{subStandard.Comment}", language));
                        }
                    }

                    document.Add(CreateParagraph("-------------------------------", language));
                }

                document.Close();

                return memoryStream.ToArray();
            }
        }
    }
}
