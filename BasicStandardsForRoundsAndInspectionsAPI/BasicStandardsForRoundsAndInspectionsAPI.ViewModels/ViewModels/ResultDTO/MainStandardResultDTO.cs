using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.ResultDTO
{
    public class MainStandardResultDTO
    {
        public string? Title { get; set; }
        public string? TitleAr { get; set; }
        public List<SubstandardResultDTO>? Substandards { get; set; }
    }
}
