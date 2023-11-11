using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PRN231_Project_QuizOnline_API.Models;

public partial class Question
{
    public int QuestionId { get; set; }

    public int TestId { get; set; }

    public string? QuestionContent { get; set; }
    [JsonIgnore]
    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();
	[JsonIgnore]
	public virtual Test Test { get; set; } = null!;
}
