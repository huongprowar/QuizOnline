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

            //QuizOnlineContext answerContext = new QuizOnlineContext();
            //foreach (var question in questions)
            //{
            //    QuestionDTO questionDTO = new QuestionDTO();
            //    questionDTO.Question = question;
            //    questionDTO.Answers = answerContext.Answers.Include(x => x.Question).Where(x => x.Question.QuestionId == question.QuestionId).ToList();
            //    listQuestion.Add(questionDTO);
            //};
            var list = _context.Questions.Include(x => x.Test).Where(x => x.Test.TestCode == code).Include(x => x.Answers).ToList();
            list.ForEach(x => listQuestion.Add(new QuestionDTO(x, x.Answers.ToList())));
            return Ok(listQuestion);
        }
        [HttpPost("/submit{testcode}")]
        public IActionResult SubmitTest(string testcode, List<RequestAnswerDTO> answers)
        {
            int numberCorrect = 0;
            _context = new QuizOnlineContext(); 
            List<Question> listQuestion = _context.Questions.Include(x => x.Answers.Where(answer => (bool)answer.IsCorrect)).Include(x => x.Test).Where(x => x.Test.TestCode == testcode).ToList();
            foreach (var question in listQuestion)
            {
                RequestAnswerDTO requestAnswerDto = answers.FirstOrDefault(x => x.QuestionId == question.QuestionId);
                if (answers.Count != requestAnswerDto.ListAnswerId.Count)
                {
                    continue;
                }
                foreach (var answer in requestAnswerDto.ListAnswerId)
                {
                    Answer tempAnswer = (question.Answers.FirstOrDefault(x => x.AnswerId == answer));
                    if (tempAnswer!=null) question.Answers.Remove(tempAnswer);
                }
                if(question.Answers.Count ==0) numberCorrect++;

            }
            return Ok(listQuestion);
        }
    }
}
