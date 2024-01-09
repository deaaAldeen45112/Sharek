using System;
using System.Collections.Generic;

namespace Sharek.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public string? Name { get; set; }

    public int? MinistryId { get; set; }

    public virtual Ministry? Ministry { get; set; }

    public virtual ICollection<Requestservice> Requestservices { get; set; } = new List<Requestservice>();
}
