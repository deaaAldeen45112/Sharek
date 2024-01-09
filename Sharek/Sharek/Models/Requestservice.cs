using System;
using System.Collections.Generic;

namespace Sharek.Models;

public partial class Requestservice
{
    public int RequestServiceId { get; set; }

    public int? RequestId { get; set; }

    public int? ServiceId { get; set; }

    public virtual Request? Request { get; set; }

    public virtual Service? Service { get; set; }
}
