using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRN231_Project_QuizOnline_API.DTO;
using PRN231_Project_QuizOnline_API.Models;

namespace PRN231_Project_QuizOnline_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        QuizOnlineContext _context { get; set; }
        [HttpGet("/{code}")]
        public IActionResult GetAllQuestionFromQuizCode(string code)
        {
            _context = new QuizOnlineContext();
            List<QuestionDTO> listQuestion  = new List<QuestionDTO>();
            var list = _context.Questions.Include(x => x.Test).Where(x => x.Test.TestCode == code).Include(x => x.Answers).ToList();
            list.ForEach(x => listQuestion.Add(new QuestionDTO(x, x.Answers.ToList())));
            return Ok(listQuestion);
        }


        [HttpPost("/submit/{testcode}")]
        public async Task<IActionResult> SubmitTest(string testcode,int userId, [FromBody] List<RequestAnswerDTO> answers)
        {
            _context = new QuizOnlineContext();
			Test test = _context.Tests.FirstOrDefault(x => x.TestCode == testcode);
			Result result = new Result()
			{
				TestId = test.TestId,
				UserId = userId,
			};
			await _context.Results.AddAsync(result);
			int numberCorrect = 0;            
            List<Question> listQuestion = _context.Questions.Include(x => x.Answers.Where(answer => (bool)answer.IsCorrect)).Include(x => x.Test).Where(x => x.Test.TestCode == testcode).ToList();
            foreach (var question in listQuestion)
            {
                RequestAnswerDTO requestAnswerDto = answers.FirstOrDefault(x => x.QuestionId == question.QuestionId);
                if (question.Answers.Count != requestAnswerDto.ListAnswerId.Count)
                {
                    continue;
                }
                foreach (var answer in requestAnswerDto.ListAnswerId)
                {
                    ResultDetail resultDetail = new ResultDetail()
                    {
                        ResultId = result.ResultId,
                        QuestionId = question.QuestionId,
                        AnswerId = answer
                    };
                    _context.ResultDetails.Add(resultDetail);
                    Answer tempAnswer = (question.Answers.FirstOrDefault(x => x.AnswerId == answer));
                    if (tempAnswer!=null) question.Answers.Remove(tempAnswer);
                }
                if(question.Answers.Count ==0) numberCorrect++;
            }
			
           
			return Ok(numberCorrect);
        }
    }
}
