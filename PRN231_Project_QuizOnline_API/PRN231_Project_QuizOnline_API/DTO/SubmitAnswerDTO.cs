namespace PRN231_Project_QuizOnline_API.DTO
{
    public class RequestAnswerDTO
    {
        public int QuestionId { get; set; }
        public List<int> ListAnswerId { get; set; }        
    }
    public class SubmitAnswerDTO
    {
        public string QuestionContent { get; set; }
        public List<string> ListAnswerContent { get; set; }
		public bool IsCorrected { get; set; }
        public List<string> SelectedAnswers { get; set; }
    }
    public class ResponseSubmitTest
    {
        public int UserID { get; set; }
        public string TestCode { get; set; }
        public float Grade { get; set; }    
        public List<SubmitAnswerDTO> Answers { get; set; }
    }
}
