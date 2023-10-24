using System;
using System.Collections.Generic;

namespace PRN231_Project_QuizOnline_API.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public string? Image { get; set; }

    public byte[]? Status { get; set; }

    public int? AuthorId { get; set; }

    public virtual User? Author { get; set; }

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}
