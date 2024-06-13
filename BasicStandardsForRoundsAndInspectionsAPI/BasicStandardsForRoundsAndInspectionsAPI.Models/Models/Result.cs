using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicStandardsForRoundsAndInspectionsAPI.Models
{
    public class Result
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        public string Description { get; set; }
        [ForeignKey("ResultType")]
        public int ResultTypeId { get; set; }
        public ResultType ResultType { get; set; }
        public List<SubStandardResult> SubStandardResults { get; set; } = new List<SubStandardResult>();
    }
}
