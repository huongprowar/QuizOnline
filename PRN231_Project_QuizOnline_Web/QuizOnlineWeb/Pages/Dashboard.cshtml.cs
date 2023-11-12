using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using QuizOnlineWeb.DTO;

namespace QuizOnlineWeb.Pages
{
    public class DashboardModel : PageModel
    {
        public List<ResultDTO> ListResult = new List<ResultDTO>();
        [HttpGet]
        public async Task<IActionResult> OnGetAsync()
        {
            int id = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            await GetResultDetail(Convert.ToInt32(id));
            return Page();
        }
        private async Task GetResultDetail(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var url = $"http://localhost:5177/api/Quiz/GetResultDetailOfUser/{id}";
                using (HttpResponseMessage res = await client.GetAsync(url))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = content.ReadAsStringAsync().Result;
                        ListResult = JsonConvert.DeserializeObject<List<ResultDTO>>(data);                        
                    }                    
                }
            }
        }

    }
}
