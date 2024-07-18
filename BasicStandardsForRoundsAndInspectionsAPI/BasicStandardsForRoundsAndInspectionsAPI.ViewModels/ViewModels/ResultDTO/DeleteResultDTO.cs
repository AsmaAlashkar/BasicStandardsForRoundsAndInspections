using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.ResultDTO
{
    public class DeleteResultDTO
    {
        public int HospitalId { get; set; }
        public DateTime ReportDate { get; set; }
        public int SubstandardId { get; set; }
    }
}
