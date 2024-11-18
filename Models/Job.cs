using System;
using System.Collections.Generic;

namespace Book_Store_Portal.Models;

public partial class Job
{
    public int JobId { get; set; }

    public string? JobDesc { get; set; }

    public decimal? MinLvl { get; set; }

    public decimal? MaxLvl { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
