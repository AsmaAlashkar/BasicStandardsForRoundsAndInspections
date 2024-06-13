using System.ComponentModel.DataAnnotations;

namespace BasicStandardsForRoundsAndInspectionsAPI.Models
{
    public class MainStandard
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Title { get; set; }

        [MaxLength(100)]
        public string? TitleAr { get; set; }
        public List<SubStandard> SubStandards { get; set; } = new List<SubStandard>();
    }
}
