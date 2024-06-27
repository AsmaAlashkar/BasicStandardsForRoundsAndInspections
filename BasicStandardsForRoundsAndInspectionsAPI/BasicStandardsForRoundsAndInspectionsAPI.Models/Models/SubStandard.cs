using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicStandardsForRoundsAndInspectionsAPI.Models
{
    public class SubStandard
    {
        [Key]
        public int Id { get; set; }
 
        public string? Description { get; set; }

        public List<Result> Results { get; set; }= new List<Result>();
        [ForeignKey("MainStandardId")]
        public int MainStandardId { get; set; }
        public MainStandard MainStandard { get; set; }
        public List<SubStandardResult>? SubStandardResults { get; set; } 

    }
}
