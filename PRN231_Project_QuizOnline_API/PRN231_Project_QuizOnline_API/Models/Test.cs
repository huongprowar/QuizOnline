﻿using System;
using System.Collections.Generic;

namespace PRN231_Project_QuizOnline_API.Models;

public partial class Test
{
    public int TestId { get; set; }

    public int CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}