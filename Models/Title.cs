using System;
using System.Collections.Generic;

namespace Book_Store_Portal.Models;

public partial class Title
{
    public int TitleId { get; set; }

    public string? Title1 { get; set; }

    public string? Type { get; set; }

    public int? PubId { get; set; }

    public decimal? Price { get; set; }

    public decimal? Advance { get; set; }

    public decimal? Royalty { get; set; }

    public decimal? YtdSales { get; set; }

    public string? Notes { get; set; }

    public DateTime? Pubdate { get; set; }

    public virtual Publisher? Pub { get; set; }
}
