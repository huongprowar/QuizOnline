using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PRN231_Project_QuizOnline_Web.Models;
using System.Security.Claims;

namespace PRN231_Project_QuizOnline_Web.Controllers
{
	public class LoginController : Controller
	{
		protected static string URL_LOGIN = "http://localhost:5177/api/User/Login";
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(string username, string password)
		{
			using (HttpClient client = new HttpClient())
			{
				
				User sendUser = new User()
				{
					Username = username,
					Password = password
				};
				using (HttpResponseMessage res = await client.PostAsJsonAsync(URL_LOGIN, sendUser))
				{
					using (HttpContent content = res.Content)
					{
						string data = content.ReadAsStringAsync().Result;
						User user = JsonConvert.DeserializeObject<User>(data);
						if (user != null)
						{
							var claims = new List<Claim>() {
						new Claim(ClaimTypes.Name, user.Username),
						new Claim(ClaimTypes.Role, user.Role == 1 ? "User" : "Admin"),
					};
							var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
							var principal = new ClaimsPrincipal(identity);
							await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties());
							return Redirect("/");
						}
					}
				}
				return View();
			}
		}
	}
}
