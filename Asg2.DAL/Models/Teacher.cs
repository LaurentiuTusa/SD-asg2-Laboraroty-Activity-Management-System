using System;
using System.Collections.Generic;

namespace Asg2.DAL.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Subject> Subjects { get; } = new List<Subject>();
}
