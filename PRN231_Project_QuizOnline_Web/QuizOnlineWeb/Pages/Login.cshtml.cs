using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using QuizOnlineWeb.DTO;

namespace QuizOnlineWeb.Pages
{
	public class LoginModel : PageModel
	{
		static string URL_GETCODE = "http://localhost:5177/";
		public void OnGet()
		{
		}

		[HttpPost]
		public async Task<IActionResult> Login(string username, string password, string testCode)
		{
			//using (HttpClient client = new HttpClient())
			//{

			//    User sendUser = new User()
			//    {
			//        Username = username,
			//        Password = password
			//    };
			//    using (HttpResponseMessage res = await client.PostAsJsonAsync("", sendUser))
			//    {
			//        using (HttpContent content = res.Content)
			//        {
			//            string data = content.ReadAsStringAsync().Result;
			//            User user = JsonConvert.DeserializeObject<User>(data);
			//            if (user != null)
			//            {
			//                var claims = new List<Claim>() {
			//            new Claim(ClaimTypes.Name, user.Username),
			//            new Claim(ClaimTypes.Role, user.Role == 1 ? "User" : "Admin"),
			//        };
			//                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
			//                var principal = new ClaimsPrincipal(identity);
			//                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties());
			//                return Redirect("/");
			//            }
			//        }
			//    }
			return Page();
		}

		
		public async Task<IActionResult> OnPostEnterTestAsync(string testCode)
		{
			List<ResponseQuestionDTO> listQuestion = new List<ResponseQuestionDTO>();
			using (HttpClient client = new HttpClient())
			{
				using (HttpResponseMessage res = await client.GetAsync(URL_GETCODE + testCode))
				{
					using (HttpContent content = res.Content)
					{
						string data = content.ReadAsStringAsync().Result;
						listQuestion = JsonConvert.DeserializeObject<List<ResponseQuestionDTO>>(data);
						TempData["listQuestion"] = data;
						ViewData["listQuestion"] = listQuestion;
					}
					return new RedirectToPageResult("DoTest", listQuestion);
				}
			}
		}
	}
}