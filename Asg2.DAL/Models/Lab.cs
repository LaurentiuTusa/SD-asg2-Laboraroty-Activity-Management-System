using System;
using System.Collections.Generic;

namespace Asg2.DAL.Models;

public partial class Lab
{
    public int Id { get; set; }

    public int SubjectId { get; set; }

    public int Number { get; set; }

    public DateTime Date { get; set; }

    public string Title { get; set; } = null!;

    public string Curricula { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? AsgName { get; set; }

    public DateTime? AsdDl { get; set; }

    public string? AsgDescription { get; set; }

    public virtual ICollection<Attendance> Attendances { get; } = new List<Attendance>();

    public virtual Subject Subject { get; set; } = null!;

    public virtual ICollection<Submision> Submisions { get; } = new List<Submision>();
}
