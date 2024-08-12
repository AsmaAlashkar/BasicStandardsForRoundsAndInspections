using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.ResultDTO
{
    public class IndexResultsForEditReportDTO
    {
        public int HospitalId { get; set; }
        public DateTime ReportDate { get; set; }
        public int? ReportTakerId { get; set; }
        public List<MainStandardResultDTO>? MainStandards { get; set; }
    }
}
