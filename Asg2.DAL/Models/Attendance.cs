using System;
using System.Collections.Generic;

namespace Asg2.DAL.Models;

public partial class Attendance
{
    public int Id { get; set; }

    public int LabId { get; set; }

    public int StudentId { get; set; }

    public virtual Lab Lab { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
