using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PRN231_Project_QuizOnline_API.Models;

public partial class Result
{
    public int ResultId { get; set; }

    public int? TestId { get; set; }

    public int? UserId { get; set; }
    [JsonIgnore]
    public virtual Test? Test { get; set; }
	[JsonIgnore]
	public virtual User? User { get; set; }
}
