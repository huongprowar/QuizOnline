namespace QuizOnlineWeb.DTO
{
    public class RequestAnswerDTO
    {

		public int QuestionId { get; set; }
		public List<int> ListAnswerId { get; set; }
		public bool IsCorrected { get; set; }
	}    
}
