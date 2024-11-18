using System;
using System.Collections.Generic;

namespace Book_Store_Portal.Models;

public partial class PubInfo
{
    public int? PubId { get; set; }

    public string? Logo { get; set; }

    public string? PrInfo { get; set; }

    public virtual Publisher? Pub { get; set; }
}
