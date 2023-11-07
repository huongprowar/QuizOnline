using PRN231_Project_QuizOnline_API.Models;

namespace PRN231_Project_QuizOnline_API.DTO
{
    public class QuestionDTO
    {
        public Question Question { get; set; }
        public List<Answer> Answers { get; set; }
        public QuestionDTO(Question question, List<Answer> answers)
        {
            Answers = answers;
            Question = question;
        }
    }
}
