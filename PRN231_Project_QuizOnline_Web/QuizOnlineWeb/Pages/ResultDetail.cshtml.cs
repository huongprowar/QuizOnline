using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using QuizOnlineWeb.DTO;

namespace QuizOnlineWeb.Pages
{
    public class ResultModel : PageModel
    {
        public ResponseSubmitTest ResultList { get; set; } 
		public async Task<IActionResult> OnGetAsync([FromQuery]int resultId)
        {
            using (HttpClient client = new HttpClient())
            {
                var url = $"http://localhost:5177/api/Quiz/GetResult?resultId={resultId}";
                using (HttpResponseMessage res = await client.GetAsync(url))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = content.ReadAsStringAsync().Result;
                        ResultList = JsonConvert.DeserializeObject<ResponseSubmitTest>(data);
                        return Page();
                    }
                    //return new RedirectToPageResult("DoTest", listQuestion);
                }
            }                                    
        }
    }
}
