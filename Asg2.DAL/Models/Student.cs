using System;
using System.Collections.Generic;

namespace Asg2.DAL.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Group { get; set; } = null!;

    public string? Hobby { get; set; }

    public virtual ICollection<Attendance> Attendances { get; } = new List<Attendance>();

    public virtual ICollection<Submision> Submisions { get; } = new List<Submision>();
}
