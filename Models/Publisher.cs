using System;
using System.Collections.Generic;

namespace Book_Store_Portal.Models;

public partial class Publisher
{
    public int PubId { get; set; }

    public string? PubName { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Title> Titles { get; set; } = new List<Title>();
}
