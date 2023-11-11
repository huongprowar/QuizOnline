using System;
using System.Collections.Generic;

namespace PRN231_Project_QuizOnline_API.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int Role { get; set; }

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
