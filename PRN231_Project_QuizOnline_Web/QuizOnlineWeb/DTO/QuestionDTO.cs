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
}
