using System;
using System.Collections.Generic;

namespace BasicStandardsForRoundsAndInspectionsAPI.Models.Models;

public partial class Result
{
    public int HospitalId { get; set; }

    public DateTime ReportDate { get; set; }

    public int? ReportTakerId { get; set; }

    public int SubstandardId { get; set; }

    public string? ResultValue { get; set; }
    public string? Comment { get; set; }
    // Navigation properties
    public Hospital Hospital { get; set; }
    public Employee? ReportTaker { get; set; }

}
