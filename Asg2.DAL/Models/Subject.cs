using System;
using System.Collections.Generic;

namespace Asg2.DAL.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string Subject1 { get; set; } = null!;

    public int TeacherId { get; set; }

    public virtual ICollection<Lab> Labs { get; } = new List<Lab>();

    public virtual Teacher Teacher { get; set; } = null!;
}
