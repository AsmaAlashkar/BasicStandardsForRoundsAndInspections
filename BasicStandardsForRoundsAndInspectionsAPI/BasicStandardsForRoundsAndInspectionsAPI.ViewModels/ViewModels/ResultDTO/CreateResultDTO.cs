using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.ResultDTO
{
    public class CreateResultDTO
    {
        public string? ResultValue { get; set; }
        public string? ResultValueAr { get; set; }
        public int ResultTypeId { get; set; }
        public int SubStandardId { get; set; }
    }
}
