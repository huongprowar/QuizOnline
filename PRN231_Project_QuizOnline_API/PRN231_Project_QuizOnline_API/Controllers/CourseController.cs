using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRN231_Project_QuizOnline_API.Models;
using PRN231_Project_QuizOnline_API.Repositories;

namespace PRN231_Project_QuizOnline_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CourseController : ControllerBase
	{
		private readonly QuizOnlineContext _context;
		public CourseController()
		{
			_context = new QuizOnlineContext();
		}
		[HttpGet]
		public async Task<List<Course>> GetAllCourse()
		{
			return await _context.Courses.ToListAsync();
		}
	}
}
