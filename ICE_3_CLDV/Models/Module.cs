using System;
using System.Collections.Generic;

namespace SMS.Models;

public partial class Module
{
    public int ModuleId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
