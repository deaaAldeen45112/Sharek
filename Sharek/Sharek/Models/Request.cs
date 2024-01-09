using System;
using System.Collections.Generic;

namespace Sharek.Models;

public partial class Request
{
    public int RequestId { get; set; }

    public string? CaseName { get; set; }

    public string? Lat { get; set; }

    public string? Lng { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Requestservice> Requestservices { get; set; } = new List<Requestservice>();

    public virtual User? User { get; set; }
}
