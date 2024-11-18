using System;
using System.Collections.Generic;

namespace Book_Store_Portal.Models;

public partial class Roysched
{
    public int? TitleId { get; set; }

    public decimal? Lorange { get; set; }

    public decimal? Hirange { get; set; }

    public decimal? Royalty { get; set; }

    public virtual Title? Title { get; set; }
}
