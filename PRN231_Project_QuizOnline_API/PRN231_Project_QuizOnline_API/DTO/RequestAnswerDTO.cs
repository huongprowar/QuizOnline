namespace PRN231_Project_QuizOnline_API.DTO
{
    public class RequestAnswerDTO
    {
        public int QuestionId { get; set; }
        public List<int> ListAnswerId { get; set; }
    }
}
