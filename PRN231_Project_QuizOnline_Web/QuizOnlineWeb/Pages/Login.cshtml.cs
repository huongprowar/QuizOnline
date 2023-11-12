using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using QuizOnlineWeb.DTO;
using System.Security.Claims;

namespace QuizOnlineWeb.Pages
{
	public class LoginModel : PageModel
	{
		static string URL_GETCODE = "http://localhost:5177/";
		public async Task<IActionResult> OnGetAsync()
		{
			ViewData["Error"] = "";
			return Page();
		}
		[BindProperty]
        public LoginUserDTO loginUser { get; set; }

        [HttpPost]
		public async Task<IActionResult> OnPostLoginAsync(string username, string password)
		{
			using (HttpClient client = new HttpClient())
			{				
				using (HttpResponseMessage res = await client.PostAsJsonAsync("http://localhost:5177/api/User/Login", loginUser))
				{
					using (HttpContent content = res.Content)
					{
						string data = content.ReadAsStringAsync().Result;
						if (string.IsNullOrEmpty(data))
						{
							ViewData["Error"] = "User not found!";
							return Page();
						}
						UserDTO user = JsonConvert.DeserializeObject<UserDTO>(data);
						if (user != null)
						{
							var claims = new List<Claim>() {
							new Claim("Id", user.UserId.ToString()),
						new Claim(ClaimTypes.Name, user.Username),
						new Claim(ClaimTypes.Role, user.Role == 1 ? "User" : "Admin"),
						};
							HttpContext.Session.SetInt32("UserID", user.UserId);
							var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
							var principal = new ClaimsPrincipal(identity);
							await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties());
                            HttpContext.Session.SetInt32("UserId", user.UserId);
                            HttpContext.Session.SetString("Username", user.Username);							
                            return Redirect("/");
						}
					}
					Claim claim = ClaimsPrincipal.Current.Identities.First().Claims.FirstOrDefault();
				}
				return Page();
			}
		}

		public async Task<IActionResult> OnPostLogoutAsync()
		{
			//var identity = (ClaimsIdentity)User.Identity;
			//IEnumerable<Claim> claims = identity.Claims;

			var scheme = CookieAuthenticationDefaults.AuthenticationScheme;
			HttpContext.Session.Remove("Username");
			HttpContext.Session.Remove("Id");
			await HttpContext.SignOutAsync(scheme);
			return RedirectToPage("/Index");

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
						TempData["TestCode"] = testCode;
						ViewData["listQuestion"] = listQuestion;
					}
					return new RedirectToPageResult("DoTest", listQuestion);
				}
			}
		}
	}
}