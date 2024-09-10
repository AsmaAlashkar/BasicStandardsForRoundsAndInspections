

namespace BasicStandardsForRoundsAndInspectionsAPI.Models.Models;

public partial class Result
{
    public int Id { get; set; }
    public int HospitalId { get; set; }
    public DateTime ReportDate { get; set; }
    public int SubstandardId { get; set; }
    public int? ReportTakerId { get; set; }
    public string? ResultValue { get; set; }
    public string? Comment { get; set; }
    // Navigation properties
    public virtual SubStandard SubStandard { get; set; }
    public Hospital? Hospital { get; set; }
    public Employee? ReportTaker { get; set; }

}
