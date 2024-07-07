using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicStandardsForRoundsAndInspectionsAPI.Models
{
    public class SubStandard
    {
        [Key]
        public int Id { get; set; }
     
        public string? Description { get; set; }
        public string? DescriptionAr { get; set; }

        [MaxLength(3)]
        public string? Code { get; set; }
        public int ResultTypeId { get; set; }
        public ResultType? ResultType { get; set; }

        public int MainStandardId { get; set; }
        public MainStandard? MainStandard { get; set; }

    }
}
