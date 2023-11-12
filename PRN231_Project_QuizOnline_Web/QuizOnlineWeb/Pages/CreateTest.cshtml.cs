using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizOnlineWeb.DTO;

namespace QuizOnlineWeb.Pages
{
    [Authorize("Admin")]
    public class CreateQuizModel : PageModel
    {
        [BindProperty]
        public string TestCode {  get; set; }
        [BindProperty]
        public List<CreateQuestionDTO> ListCreateQuestion { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostCreateQuiz()
        {
            return Page();
        }
    }
}
