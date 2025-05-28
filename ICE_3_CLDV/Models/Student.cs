using System;
using System.Collections.Generic;

namespace SMS.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string Stnumber { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
