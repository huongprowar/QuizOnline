using System.Text.Json.Serialization;

namespace QuizOnlineWeb.DTO
{    
    public class ResponseQuestionDTO
    {        
        [JsonPropertyName("question")]
        public  QuestionDTO Question{ get; set; }
        [JsonPropertyName("answers")]
        public List<AnswerDTO> Answers { get; set; }      
    }
}
