using System;
using System.Collections.Generic;

namespace Asg2.DAL.Models;

public partial class Submision
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int LabId { get; set; }

    public string Link { get; set; } = null!;

    public string? Comment { get; set; }

    public int? Grade { get; set; }

    public virtual Lab Lab { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
