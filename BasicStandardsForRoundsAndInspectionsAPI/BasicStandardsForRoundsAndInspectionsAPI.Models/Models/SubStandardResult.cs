using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicStandardsForRoundsAndInspectionsAPI.Models
{
    public class SubStandardResult
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("SubStandardId")]
        public int SubStandardId { get; set; }
        public virtual SubStandard? SubStandard { get; set; }
        [ForeignKey("ResultId")]
        public int ResultId { get; set; }
        public virtual Result? Result { get; set; }
    }
}
