using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PRN231_Project_QuizOnline_API.Models;

public partial class Test
{
    public int TestId { get; set; }

    public int? CourseId { get; set; }

    public string? TestCode { get; set; }
    [JsonIgnore]
    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
    [JsonIgnore]
    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
