using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.SubStandardDTO
{
    public class CreateSubStandardDTO
    {
        public string? Description { get; set; }
        public int MainStandardId { get; set; }
    }
}
