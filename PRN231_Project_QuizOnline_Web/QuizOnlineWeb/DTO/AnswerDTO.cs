using System.Text.Json.Serialization;

namespace QuizOnlineWeb.DTO
{
    public class AnswerDTO
    {
        [JsonPropertyName("answerId")]
        public int AnswerId { get; set; }
        [JsonPropertyName("answerContent")]
        public string AnswerContent { get; set; }
    }
    public class RequestAnswerDTO
    {

        public int QuestionId { get; set; }
        public List<int> ListAnswerId { get; set; }
        public bool IsCorrected { get; set; }
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
