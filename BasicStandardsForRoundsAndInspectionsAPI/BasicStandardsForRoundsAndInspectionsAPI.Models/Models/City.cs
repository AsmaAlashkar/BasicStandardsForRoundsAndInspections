using System;
using System.Collections.Generic;

namespace BasicStandardsForRoundsAndInspectionsAPI.Models.Models;

public partial class City
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public int GovernorateId { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longtitude { get; set; }

    public virtual Governorate Governorate { get; set; } = null!;

}
