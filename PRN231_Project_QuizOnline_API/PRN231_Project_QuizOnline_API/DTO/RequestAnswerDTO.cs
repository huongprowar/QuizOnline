namespace PRN231_Project_QuizOnline_API.DTO
{
    public class RequestAnswerDTO
    {
        public int QuestionId { get; set; }
        public List<int> ListAnswerId { get; set; }        
    }
    public class ResponseAnswerDTO
    {
        public string QuestionContent { get; set; }
        public List<string> ListAnswerContent { get; set; }
		public bool IsCorrected { get; set; }
	}
}
