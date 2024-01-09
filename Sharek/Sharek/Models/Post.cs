using System;
using System.Collections.Generic;

namespace Sharek.Models;

public partial class Post
{
    public int PostId { get; set; }

    public int? UserId { get; set; }

    public int? FromPlace { get; set; }

    public int? ToPlace { get; set; }

    public DateTime? DepartureDate { get; set; }

    public string? Note { get; set; }

    public string? Access { get; set; }

    public string? TypeOfVichle { get; set; }

    public DateTime? ArrivedTime { get; set; }

    public DateTime? CreatedDate { get; set; }

    public decimal? Price { get; set; }

    public int? AvaliableSeat { get; set; }

    public virtual Address? FromPlaceNavigation { get; set; }

    public virtual Address? ToPlaceNavigation { get; set; }

    public virtual User? User { get; set; }
}
