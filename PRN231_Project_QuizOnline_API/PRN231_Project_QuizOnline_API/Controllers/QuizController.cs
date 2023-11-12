using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using PRN231_Project_QuizOnline_API.DTO;
using PRN231_Project_QuizOnline_API.Models;

namespace PRN231_Project_QuizOnline_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        QuizOnlineContext _context { get; set; }
        [HttpGet("GetResult")]
        public async Task<IActionResult> GetResultDetail(int resultId)
        {
            _context = new QuizOnlineContext();
            Result result = _context.Results.Include(x => x.Test).FirstOrDefault(x => x.ResultId == resultId);
            ResponseSubmitTest response = new ResponseSubmitTest();
            response.TestCode = result.Test.TestCode;
            response.Answers = new();
            response.UserID = (int)result.UserId;
            List<Question> listQuestion = _context.Questions.Include(x => x.Answers).Include(x => x.Test).Where(x => x.Test.TestCode == response.TestCode).ToList();
            List<ResultDetail> resultDetails = _context.ResultDetails.Include(x => x.Question).ThenInclude(x => x.Answers).Where(x => x.ResultId == resultId).ToList();
            int totalCorrect = 0;
            foreach (var question in listQuestion)
            {
                SubmitAnswerDTO answerDTO = new SubmitAnswerDTO();
                answerDTO.IsCorrected = false;
                List<Answer> answers = question.Answers.Where(x => x.QuestionId == question.QuestionId).ToList();
                answerDTO.QuestionContent = question.QuestionContent;
                answerDTO.ListAnswerContent = question.Answers.Select(x => x.AnswerContent).ToList();
                answerDTO.SelectedAnswers = new List<string>();
                int selectedCount = 0;
                foreach (var resultDetail in resultDetails) 
                {
                    Answer answer = answers.FirstOrDefault(x => x.AnswerId == resultDetail.AnswerId && x.QuestionId == question.QuestionId);
                    if (answer != null)
                    {
                        answerDTO.SelectedAnswers.Add(answer.AnswerContent);
                        selectedCount += answer.IsCorrect ? 1 : 0;
                    }
                }
                if(selectedCount == answers.Where(x => x.IsCorrect).ToList().Count)
                {
                    totalCorrect++;
                    answerDTO.IsCorrected = true;
                }
                response.Answers.Add(answerDTO);
            }
            response.Grade = ((float)totalCorrect / listQuestion.Count)*10;
            return Ok(response);
        }
        [HttpGet("GetResultDetailOfUser/{userid}")]
        public async Task<IActionResult> GetResultDetailOfUser(int userid)
        {
            _context = new QuizOnlineContext();
            List<ResultDTO> listResult = _context.Results.Include(x => x.Test).Where(x => x.UserId == userid).Select(x => new ResultDTO() {TestCode = x.Test.TestCode, ResultID = x.ResultId }).ToList();
            return Ok(listResult);
        }
    }
}
