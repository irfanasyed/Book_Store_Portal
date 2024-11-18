using System;
using System.Collections.Generic;

namespace Book_Store_Portal.Models;

public partial class Author
{
    public int AuId { get; set; }

    public string? AuLname { get; set; }

    public string? AuFname { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public int? Contract { get; set; }
}
