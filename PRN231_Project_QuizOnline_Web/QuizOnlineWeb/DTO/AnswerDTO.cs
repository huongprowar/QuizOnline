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
}
