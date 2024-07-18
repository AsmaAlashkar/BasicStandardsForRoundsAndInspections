using System;
using System.Collections.Generic;

namespace BasicStandardsForRoundsAndInspectionsAPI.Models.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? Position { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

}
