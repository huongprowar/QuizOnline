using System;
using System.Collections.Generic;

namespace PRN231_Project_QuizOnline_API.Models;

public partial class Answer
{
    public int AnswerId { get; set; }

    public string? AnswerContent { get; set; }

    public bool? IsCorrect { get; set; }

    public int? QuestionId { get; set; }

    public virtual Question? Question { get; set; }
}
