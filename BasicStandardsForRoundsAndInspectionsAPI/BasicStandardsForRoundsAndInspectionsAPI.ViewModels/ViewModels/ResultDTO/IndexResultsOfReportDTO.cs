using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.MainstandardDTO;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.SubStandardDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.ResultDTO
{
    public class IndexResultsOfReportDTO
    {
        public int HospitalId { get; set; }
        public string? HospitalName { get; set; }
        public string? HospitalNameAr { get; set; }
        public DateTime ReportDate { get; set; }
        public int? ReportTakerId { get; set; }
        public string? ReportTakerName { get; set; }
        public List<MainStandardResultDTO>? MainStandards { get; set; }

    }
}
