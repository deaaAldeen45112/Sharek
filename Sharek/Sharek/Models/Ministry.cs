using System;
using System.Collections.Generic;

namespace Sharek.Models;

public partial class Ministry
{
    public int MinistryId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
