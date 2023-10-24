using System;
using System.Collections.Generic;

namespace PRN231_Project_QuizOnline_API.Models;

public partial class Question
{
    public int QuestionId { get; set; }

    public int TestId { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual Test Test { get; set; } = null!;
}
