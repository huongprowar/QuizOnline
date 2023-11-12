using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PRN231_Project_QuizOnline_API.Models;

public partial class Answer
{
    public int AnswerId { get; set; }

    public string? AnswerContent { get; set; }

    public bool IsCorrect { get; set; }

    public int? QuestionId { get; set; }
    [JsonIgnore]
    public virtual Question? Question { get; set; }
}
