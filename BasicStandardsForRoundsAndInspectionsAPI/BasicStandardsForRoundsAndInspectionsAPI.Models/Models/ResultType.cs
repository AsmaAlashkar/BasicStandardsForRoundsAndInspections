using System.ComponentModel.DataAnnotations;

namespace BasicStandardsForRoundsAndInspectionsAPI.Models
{
    public class ResultType
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public IEnumerable<SubStandard>? SubStandards { get; set; }
        public IEnumerable<Result>? Results { get; set; }


    }
}
