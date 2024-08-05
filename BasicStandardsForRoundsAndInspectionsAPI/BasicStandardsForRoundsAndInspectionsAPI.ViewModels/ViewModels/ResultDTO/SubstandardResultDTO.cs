using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.ResultDTO
{
    public class SubstandardResultDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? DescriptionAr { get; set; }
        public string? ResultValue { get; set; }
        public string? Comment { get; set; }
        public int ResultTypeId { get; set; }
    }
}
