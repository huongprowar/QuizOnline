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
        QuizOnlineContext quizOnlineContext { get; set; }
        [HttpGet("/{code}")]
        public IActionResult GetAllQuestionFromQuizCode(string code)
        {
            quizOnlineContext = new QuizOnlineContext();
            List<QuestionDTO> listQuestion  = new List<QuestionDTO>();

            //QuizOnlineContext answerContext = new QuizOnlineContext();
            //foreach (var question in questions)
            //{
            //    QuestionDTO questionDTO = new QuestionDTO();
            //    questionDTO.Question = question;
            //    questionDTO.Answers = answerContext.Answers.Include(x => x.Question).Where(x => x.Question.QuestionId == question.QuestionId).ToList();
            //    listQuestion.Add(questionDTO);
            //};
            var list = quizOnlineContext.Questions.Include(x => x.Test).Where(x => x.Test.TestCode == code).Include(x => x.Answers).ToList();
            list.ForEach(x => listQuestion.Add(new QuestionDTO(x, x.Answers.ToList())));
            return Ok(listQuestion);
        }
    }
}
