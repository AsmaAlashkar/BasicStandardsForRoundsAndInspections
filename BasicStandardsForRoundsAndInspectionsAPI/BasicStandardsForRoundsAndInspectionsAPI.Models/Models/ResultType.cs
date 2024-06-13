using System.ComponentModel.DataAnnotations;

namespace BasicStandardsForRoundsAndInspectionsAPI.Models
{
    public class ResultType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Result> Results { get; set; } = new List<Result>();
    }
}
