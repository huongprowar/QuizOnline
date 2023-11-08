using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using QuizOnlineWeb.DTO;

namespace QuizOnlineWeb.Pages
{
    public class DoTestModel : PageModel
    {
        public List<ResponseQuestionDTO> questionDTOs { get; set; } = new List<ResponseQuestionDTO> {};
        public async Task<IActionResult> OnGetAsync(List<ResponseQuestionDTO> listQuestion)
        {
            //questionDTOs = TempData["listQuestion"];
            var data = TempData["listQuestion"] as string;

			questionDTOs = JsonConvert.DeserializeObject<List<ResponseQuestionDTO>>(data);

			return Page();
        }        
        public async Task<IActionResult> OnPostSubmitTest(string data)
        {
            return Page();
        }
    }
}
