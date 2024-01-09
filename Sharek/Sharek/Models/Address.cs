using System;
using System.Collections.Generic;

namespace Sharek.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public string? Place { get; set; }

    public virtual ICollection<Post> PostFromPlaceNavigations { get; set; } = new List<Post>();

    public virtual ICollection<Post> PostToPlaceNavigations { get; set; } = new List<Post>();
}
