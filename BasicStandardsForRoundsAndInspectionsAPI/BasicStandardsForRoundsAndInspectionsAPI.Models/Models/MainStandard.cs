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
        //[MaxLength(10)]
        //public string? Code { get; set; }
        //[MaxLength(10)]
        //public string? CodeAr { get; set; }

        public List<SubStandard>? SubStandards { get; set; }
    }
}
