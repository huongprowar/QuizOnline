using System;
using System.Collections.Generic;

namespace PRN231_Project_QuizOnline_API.Models;

public partial class Result
{
    public int UserId { get; set; }

    public int AnswerId { get; set; }

    public int ResultId { get; set; }

    public virtual Answer Answer { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
