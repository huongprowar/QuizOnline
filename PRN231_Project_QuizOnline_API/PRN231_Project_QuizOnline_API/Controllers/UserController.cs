using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN231_Project_QuizOnline_API.Models;
using PRN231_Project_QuizOnline_API.Repositories;

namespace PRN231_Project_QuizOnline_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly UserRepository _userRepository;
		public UserController()
		{
			_userRepository = new UserRepository();
		}

		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login(User user)
		{
			User resuser = await _userRepository.Login(user.Username, user.Password);
			if (resuser != null)
			{
				return Ok(resuser);
			}
			else
			{
				return NotFound();
			}			
		}
		[HttpPost]
		[Route("Register")]
		public async Task<IActionResult> Register(string username, string password, string firstName, string lastName)
		{
			User user = await _userRepository.Register(username, password, firstName, lastName);
			if (user != null)
			{
				return Ok(user);
			}
			else
			{
				return NotFound("User already exist");
			}			
		}
	}
}
