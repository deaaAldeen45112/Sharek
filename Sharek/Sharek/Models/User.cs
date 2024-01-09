using System;
using System.Collections.Generic;

namespace Sharek.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Phone { get; set; }

    public string? Ssid { get; set; }

    public string? Role { get; set; }

    public int? MinistryId { get; set; }

    public string? IsAbleToSendPost { get; set; }

    public virtual Ministry? Ministry { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
