using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace BasicStandardsForRoundsAndInspectionsAPI.Models
{
    public class Result
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Description { get; set; }
        public string? DescriptionAr { get; set; }
        public int SubStandardId { get; set; }
        public SubStandard? SubStandard { get; set; }
        public int ResultTypeId { get; set; }
        public ResultType? ResultType { get; set; }
    }
}
