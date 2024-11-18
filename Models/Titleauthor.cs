using System;
using System.Collections.Generic;

namespace Book_Store_Portal.Models;

public partial class Titleauthor
{
    public int? AuId { get; set; }

    public int? TitleId { get; set; }

    public string? AuOrd { get; set; }

    public decimal? Royaltyper { get; set; }

    public virtual Author? Au { get; set; }

    public virtual Title? Title { get; set; }
}
