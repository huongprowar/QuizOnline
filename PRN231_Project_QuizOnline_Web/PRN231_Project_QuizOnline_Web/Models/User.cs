using System;
using System.Collections.Generic;

namespace PRN231_Project_QuizOnline_Web.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int Role { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
