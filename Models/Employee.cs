using System;
using System.Collections.Generic;

namespace Book_Store_Portal.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string? Fname { get; set; }

    public string? Minit { get; set; }

    public string? Lname { get; set; }

    public int? JobId { get; set; }

    public string? JobLvl { get; set; }

    public int? PubId { get; set; }

    public DateTime? HireDate { get; set; }

    public virtual Job? Job { get; set; }

    public virtual Publisher? Pub { get; set; }
}
