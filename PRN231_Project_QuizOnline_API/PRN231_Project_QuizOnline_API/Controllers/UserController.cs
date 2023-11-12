using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PRN231_Project_QuizOnline_API.DTO;
using PRN231_Project_QuizOnline_API.Models;

namespace PRN231_Project_QuizOnline_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{

		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login(LoginUserDTO loginUser)
		{
			QuizOnlineContext context = new QuizOnlineContext();
			User user = context.Users.FirstOrDefault(x => x.Username == loginUser.username && x.Password == loginUser.password);
			if (user != null)
			{
				return Ok(user);
			}
			return NotFound("User not found");
		}
	}
}
