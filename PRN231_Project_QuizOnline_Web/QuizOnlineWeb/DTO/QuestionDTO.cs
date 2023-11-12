using System.Text.Json.Serialization;

namespace QuizOnlineWeb.DTO
{
	public class QuestionDTO
	{
		[JsonPropertyName("questionId")]
		public int QuestionId { get; set; }
		[JsonPropertyName("testId")]
		public int? TestId { get; set; }
		[JsonPropertyName("questionContent")]
		public string? QuestionContent { get; set; }
	}
    public class ResponseQuestionDTO
    {
        [JsonPropertyName("question")]
        public QuestionDTO Question { get; set; }
        [JsonPropertyName("answers")]
        public List<AnswerDTO> Answers { get; set; }
    }
	public class CreateQuestionDTO
	{
		public string QuestionContent { get; set; }
		public List<string> Answers { get; set; } = new List<string>();
	}
}
