using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizOnlineWeb.DTO;

namespace QuizOnlineWeb.Pages
{
    public class ResultModel : PageModel
    {
        public List<RequestAnswerDTO> ResultList { get; set; }
		public async Task<IActionResult> OnGetAsync(List<RequestAnswerDTO> resultList)
        {
            ResultList = resultList;
            return Page();
        }
    }
}
