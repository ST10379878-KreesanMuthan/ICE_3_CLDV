using System;
using System.Collections.Generic;

namespace SMS.Models;

public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public int StudentId { get; set; }

    public int? ModuleId { get; set; }

    public string Status { get; set; } = null!;

    public int Semester { get; set; }

    public virtual Module? Module { get; set; }

    public virtual Student Student { get; set; } = null!;
}
