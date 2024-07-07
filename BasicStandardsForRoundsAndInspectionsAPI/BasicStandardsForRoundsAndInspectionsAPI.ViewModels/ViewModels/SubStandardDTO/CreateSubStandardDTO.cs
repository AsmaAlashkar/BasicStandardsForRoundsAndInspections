using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.SubStandardDTO
{
    public class CreateSubStandardDTO
    {
        public string? DescriptionAr { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public int MainStandardId { get; set; }
    }
}
