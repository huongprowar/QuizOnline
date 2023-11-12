using System;
using System.Collections.Generic;

namespace PRN231_Project_QuizOnline_API.Models;

public partial class Result
{
    public int ResultId { get; set; }

    public int? TestId { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<ResultDetail> ResultDetails { get; set; } = new List<ResultDetail>();

    public virtual Test? Test { get; set; }

    public virtual User? User { get; set; }
}
