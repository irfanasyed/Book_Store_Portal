using System;
using System.Collections.Generic;

namespace Book_Store_Portal.Models;

public partial class Discount
{
    public string? Discounttype { get; set; }

    public int? StorId { get; set; }

    public int? Lowqty { get; set; }

    public int? Highqty { get; set; }

    public decimal? Discount1 { get; set; }

    public virtual Store? Stor { get; set; }
}
