using System;
using System.Collections.Generic;

namespace PRN231_Project_QuizOnline_API.Models;

public partial class ResultDetail
{
    public int ResultId { get; set; }

    public int QuestionId { get; set; }

    public int AnswerId { get; set; }

    public virtual Question Question { get; set; } = null!;

    public virtual Result Result { get; set; } = null!;
}
