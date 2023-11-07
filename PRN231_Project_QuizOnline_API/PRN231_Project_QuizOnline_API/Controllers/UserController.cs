using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PRN231_Project_QuizOnline_API.Models;

namespace PRN231_Project_QuizOnline_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{		

		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login(User user)
		{
			return Ok();
		}
	}
}
